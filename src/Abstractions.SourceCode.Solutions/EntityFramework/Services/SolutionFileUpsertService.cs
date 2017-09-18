using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework.Services
{
    public class SolutionFileUpsertService<TDbContext> : UpsertService<TDbContext, SolutionFile>
        where TDbContext : SourceCodeSolutionsDbContext
    {
        private readonly IUpsertService<TDbContext, File> _files;

        public SolutionFileUpsertService(ICacheService<SolutionFile> cache, TDbContext database, IUpsertService<TDbContext, File> files, ILogger<UpsertService<TDbContext, SolutionFile>> logger) : base(cache, database, logger, database.SolutionFiles)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(SolutionFile)}={record.FileId}:{record.SolutionFolderId}";
            _files = files ?? throw new ArgumentNullException(nameof(files));
        }

        protected override Task<SolutionFile> AssignComputedProperties(SolutionFile record)
        {
            if (record.Guid == null) record.Guid = Guid.NewGuid();
            return Task.FromResult(record);
        }

        protected override async Task<SolutionFile> AssignUpsertedReferences(SolutionFile record)
        {
            record.File = await _files.UpsertAsync(record.File);
            record.FileId = record.File?.FileId ?? record.FileId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(SolutionFile record)
        {
            yield return record.File;
            yield return record.SolutionFolder;
        }

        protected override Expression<Func<SolutionFile, bool>> FindExisting(SolutionFile record)
            => existing
                => existing.FileId == record.FileId
                && existing.SolutionFolderId == record.SolutionFolderId;
    }
}
