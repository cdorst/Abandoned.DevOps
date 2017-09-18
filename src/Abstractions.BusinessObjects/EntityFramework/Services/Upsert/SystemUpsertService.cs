
using DevOps.Abstractions.UniqueStrings;
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
    public class SystemUpsertService<TDbContext> : UpsertService<TDbContext, System>
        where TDbContext : BusinessObjectsDbContext
    {
        private readonly IUpsertListService<TDbContext, Domain> _domains;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public SystemUpsertService(TDbContext database, ILogger<UpsertService<TDbContext, System>> logger, ICacheService<System> cache, IUpsertListService<TDbContext, Domain> domains, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.Systems)
        {
            CacheKey = record => $"{nameof(BusinessObjects)}.{nameof(System)}={record.NameId}";
            _domains = domains ?? throw new ArgumentNullException(nameof(domains));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override Action<System, System> AssignChanges => (existing, given) =>
        {
            existing.Name = given.Name;
            existing.NameId = given.NameId;
        };

        protected override async Task<System> AssignUpsertedDependents(System record)
        {
            var id = record.SystemId;
            foreach (var item in record.Domains ?? new List<Domain>()) item.SystemId = id;
            record.Domains = await _domains.UpsertAsync(record.Domains);
            return record;
        }

        protected override async Task<System> AssignUpsertedReferences(System record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(System record)
        {
            yield return record.Domains;
            yield return record.Name;
        }

        protected override Expression<Func<System, bool>> FindExisting(System record)
            => existing
                => existing.NameId == record.NameId;
    }
}
