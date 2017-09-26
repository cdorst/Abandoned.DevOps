using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class AccessorListUpsertService<TDbContext> : UpsertService<TDbContext, AccessorList>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public AccessorListUpsertService(ICacheService<AccessorList> cache, TDbContext database, ILogger<UpsertService<TDbContext, AccessorList>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.AccessorLists)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(Expression)}={record.ListIdentifierId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<AccessorList> AssignUpsertedReferences(AccessorList record)
        {
            record.ListIdentifier = await _strings.UpsertAsync(record.ListIdentifier);
            record.ListIdentifierId = record.ListIdentifier?.AsciiStringReferenceId ?? record.ListIdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(AccessorList record)
        {
            yield return record.AccessorListAssociations;
            yield return record.ListIdentifier;
        }

        protected override Expression<Func<AccessorList, bool>> FindExisting(AccessorList record)
            => existing => existing.ListIdentifierId == record.ListIdentifierId;
    }
}
