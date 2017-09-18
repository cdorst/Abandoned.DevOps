using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework.Services
{
    public class NuGetFeedUpsertService<TDbContext> : UpsertService<TDbContext, NuGetFeed>
        where TDbContext : SourceCodeSolutionsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public NuGetFeedUpsertService(ICacheService<NuGetFeed> cache, TDbContext database, ILogger<UpsertService<TDbContext, NuGetFeed>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.NuGetFeeds)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(NuGetFeed)}={record.NameId}:{record.SolutionId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<NuGetFeed> AssignUpsertedReferences(NuGetFeed record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(NuGetFeed record)
        {
            yield return record.Name;
            yield return record.Solution;
        }

        protected override Expression<Func<NuGetFeed, bool>> FindExisting(NuGetFeed record)
            => existing
                => existing.NameId == record.NameId
                && existing.SolutionId == record.SolutionId;
    }
}
