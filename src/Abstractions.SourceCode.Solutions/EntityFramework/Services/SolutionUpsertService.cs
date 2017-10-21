using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework.Services
{
    public class SolutionUpsertService<TDbContext> : UpsertService<TDbContext, Solution>
        where TDbContext : SourceCodeSolutionsDbContext
    {
        private readonly IUpsertListService<TDbContext, NuGetFeed> _nuGetFeeds;
        private readonly IUpsertListService<TDbContext, SolutionFolder> _solutionFolders;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public SolutionUpsertService(ICacheService<Solution> cache, TDbContext database, ILogger<UpsertService<TDbContext, Solution>> logger, IUpsertListService<TDbContext, NuGetFeed> nuGetFeeds, IUpsertListService<TDbContext, SolutionFolder> solutionFolders, IUpsertService<TDbContext, AsciiStringReference> strings) : base(cache, database, logger, database.Solutions)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(Solution)}={record.NameId}";
            _nuGetFeeds = nuGetFeeds ?? throw new ArgumentNullException(nameof(nuGetFeeds));
            _solutionFolders = solutionFolders ?? throw new ArgumentNullException(nameof(solutionFolders));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override Action<Solution, Solution> AssignChanges => (existing, given) =>
        {
            existing.NuGetFeeds = given.NuGetFeeds;
            existing.SolutionFolders = given.SolutionFolders;
        };

        protected override Task<Solution> AssignComputedProperties(Solution record)
        {
            if (record.Guid == null) record.Guid = SlnGuidTypes.Solution;
            return Task.FromResult(record);
        }

        protected override async Task<Solution> AssignUpsertedDependents(Solution record)
        {
            var id = record.SolutionId;
            foreach (var item in record.NuGetFeeds ?? new List<NuGetFeed>()) item.SolutionId = id;
            foreach (var item in record.SolutionFolders ?? new List<SolutionFolder>()) item.SolutionId = id;
            record.NuGetFeeds = await _nuGetFeeds.UpsertAsync(record.NuGetFeeds);
            record.SolutionFolders = await _solutionFolders.UpsertAsync(record.SolutionFolders);
            return record;
        }

        protected override async Task<Solution> AssignUpsertedReferences(Solution record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Solution record)
        {
            yield return record.Name;
            yield return record.NuGetFeeds;
            yield return record.SolutionFolders;
        }

        protected override Expression<Func<Solution, bool>> FindExisting(Solution record)
            => existing => existing.NameId == record.NameId;
    }
}
