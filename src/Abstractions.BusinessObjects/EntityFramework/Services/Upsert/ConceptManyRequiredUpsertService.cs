using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert
{
    public class ConceptManyRequiredUpsertService<TDbContext> : UpsertService<TDbContext, ConceptManyRequired>
        where TDbContext : BusinessObjectsDbContext
    {
        private readonly IUpsertService<TDbContext, Concept> _concepts;

        public ConceptManyRequiredUpsertService(ICacheService<ConceptManyRequired> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConceptManyRequired>> logger, IUpsertService<TDbContext, Concept> concepts)
            : base(cache, database, logger, database.ConceptManyRequireds)
        {
            CacheKey = record => $"{nameof(BusinessObjects)}.{nameof(ConceptManyRequired)}={record.Concept1Id}:{record.Concept2Id}";
            _concepts = concepts ?? throw new ArgumentNullException(nameof(concepts));
        }

        protected override async Task<ConceptManyRequired> AssignUpsertedReferences(ConceptManyRequired record)
        {
            record.Concept1 = await _concepts.UpsertAsync(record.Concept1);
            record.Concept1Id = record.Concept1?.ConceptId ?? record.Concept1Id;
            record.Concept2 = await _concepts.UpsertAsync(record.Concept2);
            record.Concept2Id = record.Concept2?.ConceptId ?? record.Concept2Id;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ConceptManyRequired record)
        {
            yield return record.Concept1;
            yield return record.Concept2;
        }

        protected override Expression<Func<ConceptManyRequired, bool>> FindExisting(ConceptManyRequired record)
            => existing
                => existing.Concept1Id == record.Concept1Id
                && existing.Concept2Id == record.Concept2Id;
    }
}
