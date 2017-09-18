using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework.Services
{
    public class ProjectFileUpsertService<TDbContext> : UpsertService<TDbContext, ProjectFile>
        where TDbContext : SourceCodeSolutionsDbContext
    {
        private readonly IUpsertService<TDbContext, File> _files;

        public ProjectFileUpsertService(ICacheService<ProjectFile> cache, TDbContext database, IUpsertService<TDbContext, File> files, ILogger<UpsertService<TDbContext, ProjectFile>> logger) : base(cache, database, logger, database.ProjectFiles)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(ProjectFile)}={record.FileId}:{record.ProjectId}";
            _files = files ?? throw new ArgumentNullException(nameof(files));
        }

        protected override async Task<ProjectFile> AssignUpsertedReferences(ProjectFile record)
        {
            record.File = await _files.UpsertAsync(record.File);
            record.FileId = record.File?.FileId ?? record.FileId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ProjectFile record)
        {
            yield return record.File;
            yield return record.Project;
        }

        protected override Expression<Func<ProjectFile, bool>> FindExisting(ProjectFile record)
            => existing
                => existing.FileId == record.FileId
                && existing.ProjectId == record.ProjectId;
    }
}
