using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class UsingDirectiveListUpsertService<TDbContext> : UpsertService<TDbContext, UsingDirectiveList>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public UsingDirectiveListUpsertService(ICacheService<UsingDirectiveList> cache, TDbContext database, ILogger<UpsertService<TDbContext, UsingDirectiveList>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.UsingDirectiveLists)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(Expression)}={record.ListIdentifierId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<UsingDirectiveList> AssignUpsertedReferences(UsingDirectiveList record)
        {
            record.ListIdentifier = await _strings.UpsertAsync(record.ListIdentifier);
            record.ListIdentifierId = record.ListIdentifier?.AsciiStringReferenceId ?? record.ListIdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(UsingDirectiveList record)
        {
            yield return record.UsingDirectiveListAssociations;
            yield return record.ListIdentifier;
        }

        protected override Expression<Func<UsingDirectiveList, bool>> FindExisting(UsingDirectiveList record)
            => existing => existing.ListIdentifierId == record.ListIdentifierId;
    }
}
