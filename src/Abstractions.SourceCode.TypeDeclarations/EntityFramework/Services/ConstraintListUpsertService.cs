using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class ConstraintListUpsertService<TDbContext> : UpsertService<TDbContext, ConstraintList>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public ConstraintListUpsertService(ICacheService<ConstraintList> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConstraintList>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.ConstraintLists)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(Expression)}={record.ListIdentifierId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<ConstraintList> AssignUpsertedReferences(ConstraintList record)
        {
            record.ListIdentifier = await _strings.UpsertAsync(record.ListIdentifier);
            record.ListIdentifierId = record.ListIdentifier?.AsciiStringReferenceId ?? record.ListIdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ConstraintList record)
        {
            yield return record.ConstraintListAssociations;
            yield return record.ListIdentifier;
        }

        protected override Expression<Func<ConstraintList, bool>> FindExisting(ConstraintList record)
            => existing => existing.ListIdentifierId == record.ListIdentifierId;
    }
}
