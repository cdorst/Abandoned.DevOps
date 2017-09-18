using DevOps.Abstractions.Core.Options;
using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert
{
    public class ConceptManyOptionalUpsertService<TDbContext> : UpsertService<TDbContext, ConceptManyOptional>
        where TDbContext : BusinessObjectsDbContext
    {
        private readonly IUpsertService<TDbContext, Concept> _concepts;

        public ConceptManyOptionalUpsertService(ICacheService<ConceptManyOptional> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConceptManyOptional>> logger, IUpsertService<TDbContext, Concept> concepts)
            : base(cache, database, logger, database.ConceptManyOptionals)
        {
            CacheKey = record => $"{nameof(BusinessObjects)}.{nameof(ConceptManyOptional)}={record.Concept1Id}:{record.Concept2Id}";
            _concepts = concepts ?? throw new ArgumentNullException(nameof(concepts));
        }

        protected override async Task<ConceptManyOptional> AssignUpsertedReferences(ConceptManyOptional record)
        {
            record.Concept1 = await _concepts.UpsertAsync(record.Concept1);
            record.Concept1Id = record.Concept1?.ConceptId ?? record.Concept1Id;
            record.Concept2 = await _concepts.UpsertAsync(record.Concept2);
            record.Concept2Id = record.Concept2?.ConceptId ?? record.Concept2Id;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ConceptManyOptional record)
        {
            yield return record.Concept1;
            yield return record.Concept2;
        }

        protected override Expression<Func<ConceptManyOptional, bool>> FindExisting(ConceptManyOptional record)
            => existing
                => existing.Concept1Id == record.Concept1Id
                && existing.Concept2Id == record.Concept2Id;
    }
}
