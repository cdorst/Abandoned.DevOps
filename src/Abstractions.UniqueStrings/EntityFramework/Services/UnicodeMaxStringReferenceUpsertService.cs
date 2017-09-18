using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Data.HashFunction;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Abstractions.UniqueStrings.EntityFramework.Services
{
    public class UnicodeMaxStringReferenceUpsertService<TDbContext> : UpsertService<TDbContext, UnicodeMaxStringReference>
        where TDbContext : UniqueStringsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public UnicodeMaxStringReferenceUpsertService(ICacheService<UnicodeMaxStringReference> cache, TDbContext database, ILogger<UpsertService<TDbContext, UnicodeMaxStringReference>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.UnicodeMaxStringReferences)
        {
            CacheKey = record => $"{nameof(UniqueStrings)}.{nameof(UnicodeMaxStringReference)}={record.HashId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<UnicodeMaxStringReference> AssignUpsertedReferences(UnicodeMaxStringReference record)
        {
            var bytes = new xxHash(64).ComputeHash(Encoding.UTF8.GetBytes(record.Value));
            var hash = new AsciiStringReference { Value = Convert.ToBase64String(bytes) };
            hash = await _strings.UpsertAsync(hash);
            record.Hash = hash;
            record.HashId = hash.AsciiStringReferenceId;
            return record;
        }

        protected override Expression<Func<UnicodeMaxStringReference, bool>> FindExisting(UnicodeMaxStringReference record)
            => existing => existing.Hash == record.Hash;
    }
}
