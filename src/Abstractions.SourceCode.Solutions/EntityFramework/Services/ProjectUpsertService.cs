using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework.Services
{
    public class ProjectUpsertService<TDbContext> : UpsertService<TDbContext, Project>
        where TDbContext : SourceCodeSolutionsDbContext
    {
        private readonly IUpsertListService<TDbContext, ProjectFile> _projectFiles;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public ProjectUpsertService(ICacheService<Project> cache, TDbContext database, ILogger<UpsertService<TDbContext, Project>> logger, IUpsertListService<TDbContext, ProjectFile> projectFiles, IUpsertService<TDbContext, AsciiStringReference> strings) : base(cache, database, logger, database.Projects)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(Project)}={record.NameId}:{record.SolutionFolderId}";
            _projectFiles = projectFiles ?? throw new ArgumentNullException(nameof(projectFiles));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override Action<Project, Project> AssignChanges => (existing, given) => existing.ProjectFiles = given.ProjectFiles;

        protected override Task<Project> AssignComputedProperties(Project record)
        {
            if (record.Guid == null) record.Guid = Guid.NewGuid();
            return Task.FromResult(record);
        }

        protected override async Task<Project> AssignUpsertedDependents(Project record)
        {
            var id = record.ProjectId;
            foreach (var item in record.ProjectFiles ?? new List<ProjectFile>()) item.ProjectId = id;
            record.ProjectFiles = await _projectFiles.UpsertAsync(record.ProjectFiles);
            return record;
        }

        protected override async Task<Project> AssignUpsertedReferences(Project record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Project record)
        {
            yield return record.Name;
            yield return record.SolutionFolder;
            yield return record.ProjectFiles;
        }

        protected override Expression<Func<Project, bool>> FindExisting(Project record)
            => existing 
                => existing.NameId == record.NameId
                && existing.SolutionFolderId == record.SolutionFolderId;
    }
}
