using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert
{
    public class DomainUpsertService<TDbContext> : UpsertService<TDbContext, Domain>
        where TDbContext : BusinessObjectsDbContext
    {
        private readonly IUpsertListService<TDbContext, Schema> _schemas;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public DomainUpsertService(ICacheService<Domain> cache, TDbContext database, ILogger<UpsertService<TDbContext, Domain>> logger, IUpsertListService<TDbContext, Schema> schemas, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.Domains)
        {
            CacheKey = record => $"{nameof(BusinessObjects)}.{nameof(Domain)}={record.NameId}:{record.SystemId}";
            _schemas = schemas ?? throw new ArgumentNullException(nameof(schemas));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<Domain> AssignUpsertedDependents(Domain record)
        {
            var id = record.DomainId;
            foreach (var item in record.Schemas ?? new List<Schema>()) item.DomainId = id;
            record.Schemas = await _schemas.UpsertAsync(record.Schemas);
            return record;
        }

        protected override async Task<Domain> AssignUpsertedReferences(Domain record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Domain record)
        {
            yield return record.Name;
            yield return record.Schemas;
            yield return record.System;
        }

        protected override Expression<Func<Domain, bool>> FindExisting(Domain record)
            => existing
                => existing.NameId == record.NameId
                && existing.SystemId == record.SystemId;
    }
}
