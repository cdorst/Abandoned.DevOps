using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert
{
    public class ConceptPropertyUpsertService<TDbContext> : UpsertService<TDbContext, ConceptProperty>
        where TDbContext : BusinessObjectsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public ConceptPropertyUpsertService(ICacheService<ConceptProperty> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConceptProperty>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.ConceptProperties)
        {
            CacheKey = record => $"{nameof(BusinessObjects)}.{nameof(ConceptProperty)}={record.ConceptId}:{record.ImportNamespaceId}:{record.NameId}:{record.TypeId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<ConceptProperty> AssignUpsertedReferences(ConceptProperty record)
        {
            record.ImportNamespace = await _strings.UpsertAsync(record.ImportNamespace);
            record.ImportNamespaceId = record.ImportNamespace.AsciiStringReferenceId;
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name.AsciiStringReferenceId;
            record.Type = await _strings.UpsertAsync(record.Type);
            record.TypeId = record.Type.AsciiStringReferenceId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ConceptProperty record)
        {
            yield return record.Concept;
            yield return record.ImportNamespace;
            yield return record.Name;
            yield return record.Type;
        }

        protected override Expression<Func<ConceptProperty, bool>> FindExisting(ConceptProperty record)
            => existing
                => existing.ConceptId == record.ConceptId
                && existing.ImportNamespaceId == record.ImportNamespaceId
                && existing.NameId == record.NameId
                && existing.TypeId == record.TypeId;
    }
}
