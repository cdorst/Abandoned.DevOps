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
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(NuGetFeed)}={record.ValueId}:{record.SolutionId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<NuGetFeed> AssignUpsertedReferences(NuGetFeed record)
        {
            record.Value = await _strings.UpsertAsync(record.Value);
            record.ValueId = record.Value?.AsciiStringReferenceId ?? record.ValueId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(NuGetFeed record)
        {
            yield return record.Value;
            yield return record.Solution;
        }

        protected override Expression<Func<NuGetFeed, bool>> FindExisting(NuGetFeed record)
            => existing
                => existing.ValueId == record.ValueId
                && existing.SolutionId == record.SolutionId;
    }
}
