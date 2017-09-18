using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.EntityFramework.Services
{
    public class FileContentUpsertService<TDbContext> : UpsertService<TDbContext, FileContent>
        where TDbContext : SourceCodeDbContext
    {
        private readonly IUpsertService<TDbContext, UnicodeMaxStringReference> _strings;

        public FileContentUpsertService(ICacheService<FileContent> cache, TDbContext database, ILogger<UpsertService<TDbContext, FileContent>> logger, IUpsertService<TDbContext, UnicodeMaxStringReference> strings)
            : base(cache, database, logger, database.FileContents)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(FileContent)}={record.ContentId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override Task<FileContent> AssignUpsertedReferences(FileContent record)
        {
            record.DateAdded = DateTimeOffset.UtcNow;
            return Task.FromResult(record);
        }

        protected override Expression<Func<FileContent, bool>> FindExisting(FileContent record)
            => existing => existing.ContentId == record.ContentId;
    }
}
