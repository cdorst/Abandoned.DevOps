using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert
{
    public class SchemaUpsertService<TDbContext> : UpsertService<TDbContext, Schema>
        where TDbContext : BusinessObjectsDbContext
    {
        private readonly IUpsertListService<TDbContext, Concept> _concepts;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public SchemaUpsertService(ICacheService<Schema> cache, TDbContext database, ILogger<UpsertService<TDbContext, Schema>> logger, IUpsertListService<TDbContext, Concept> concepts, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.Schemas)
        {
            CacheKey = record => $"{nameof(BusinessObjects)}.{nameof(Schema)}={record.NameId}:{record.DomainId}";
            _concepts = concepts ?? throw new ArgumentNullException(nameof(concepts));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override Action<Schema, Schema> AssignChanges => (existing, given) =>
        {
            existing.Concepts = given.Concepts;
        };

        protected override async Task<Schema> AssignUpsertedDependents(Schema record)
        {
            var id = record.DomainId;
            foreach (var item in record.Concepts ?? new List<Concept>()) item.SchemaId = id;
            record.Concepts = await _concepts.UpsertAsync(record.Concepts);
            return record;
        }

        protected override async Task<Schema> AssignUpsertedReferences(Schema record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Schema record)
        {
            yield return record.Concepts;
            yield return record.Domain;
            yield return record.Name;
        }

        protected override Expression<Func<Schema, bool>> FindExisting(Schema record)
            => existing
                => existing.DomainId == record.DomainId
                && existing.NameId == record.NameId;
    }
}
