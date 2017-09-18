using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevOps.Abstractions.UniqueStrings;

namespace DevOps.Abstractions.SourceCode.EntityFramework.Services
{
    public class FileUpsertService<TDbContext> : UpsertService<TDbContext, File>
        where TDbContext : SourceCodeDbContext
    {
        private readonly IUpsertService<TDbContext, FileContent> _fileContent;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public FileUpsertService(ICacheService<File> cache, TDbContext database, IUpsertService<TDbContext, FileContent> fileContent, ILogger<UpsertService<TDbContext, File>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.Files)
        {
            _fileContent = fileContent ?? throw new ArgumentNullException(nameof(fileContent));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(File)}={record.FileContentId}:{record.NameId}:{record.PathId}";
        }

        protected override Action<File, File> AssignChanges => (existing, given) =>
        {
            existing.FileContent = given.FileContent;
            existing.FileContentId = given.FileContentId;
        };

        protected override async Task<File> AssignUpsertedReferences(File record)
        {
            record.FileContent = await _fileContent.UpsertAsync(record.FileContent);
            record.FileContentId = record.FileContent?.FileContentId ?? record.FileContentId;
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            record.Path = await _strings.UpsertAsync(record.Path);
            record.PathId = record.Path?.AsciiStringReferenceId ?? record.PathId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(File record)
        {
            yield return record.FileContent;
            yield return record.Name;
            yield return record.Path;
        }

        protected override Expression<Func<File, bool>> FindExisting(File record)
            => existing
                => existing.NameId == record.NameId
                && existing.PathId == record.PathId;
    }
}
