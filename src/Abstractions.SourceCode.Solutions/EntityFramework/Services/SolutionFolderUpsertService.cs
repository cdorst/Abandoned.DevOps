using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework.Services
{
    public class SolutionFolderUpsertService<TDbContext> : UpsertService<TDbContext, SolutionFolder>
        where TDbContext : SourceCodeSolutionsDbContext
    {
        private readonly IUpsertListService<TDbContext, Project> _projects;
        private readonly IUpsertListService<TDbContext, SolutionFile> _solutionFiles;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public SolutionFolderUpsertService(ICacheService<SolutionFolder> cache, TDbContext database, ILogger<UpsertService<TDbContext, SolutionFolder>> logger, IUpsertListService<TDbContext, Project> projects, IUpsertListService<TDbContext, SolutionFile> solutionFiles, IUpsertService<TDbContext, AsciiStringReference> strings) : base(cache, database, logger, database.SolutionFolders)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(SolutionFolder)}={record.NameId}";
            _projects = projects ?? throw new ArgumentNullException(nameof(projects));
            _solutionFiles = solutionFiles ?? throw new ArgumentNullException(nameof(solutionFiles));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override Action<SolutionFolder, SolutionFolder> AssignChanges => (existing, given) =>
        {
            existing.Projects = given.Projects;
            existing.SolutionFiles = given.SolutionFiles;
        };

        protected override Task<SolutionFolder> AssignComputedProperties(SolutionFolder record)
        {
            if (record.Guid == null) record.Guid = Guid.NewGuid();
            return Task.FromResult(record);
        }

        protected override async Task<SolutionFolder> AssignUpsertedDependents(SolutionFolder record)
        {
            var id = record.SolutionFolderId;
            foreach (var item in record.Projects ?? new List<Project>()) item.SolutionFolderId = id;
            foreach (var item in record.SolutionFiles ?? new List<SolutionFile>()) item.SolutionFolderId = id;
            record.Projects = await _projects.UpsertAsync(record.Projects);
            record.SolutionFiles = await _solutionFiles.UpsertAsync(record.SolutionFiles);
            return record;
        }

        protected override async Task<SolutionFolder> AssignUpsertedReferences(SolutionFolder record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(SolutionFolder record)
        {
            yield return record.Name;
            yield return record.Projects;
            yield return record.Solution;
            yield return record.SolutionFiles;
        }

        protected override Expression<Func<SolutionFolder, bool>> FindExisting(SolutionFolder record)
            => existing 
                => existing.NameId == record.NameId
                && existing.SolutionId == record.SolutionId;
    }
}
