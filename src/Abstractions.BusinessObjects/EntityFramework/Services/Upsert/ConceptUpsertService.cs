using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert
{
    public class ConceptUpsertService<TDbContext> : UpsertService<TDbContext, Concept>
        where TDbContext : BusinessObjectsDbContext
    {
        private readonly IUpsertListService<TDbContext, ConceptManyOptional> _manyOptional;
        private readonly IUpsertListService<TDbContext, ConceptManyRequired> _manyRequired;
        private readonly IUpsertListService<TDbContext, ConceptOneOptional> _oneOptional;
        private readonly IUpsertListService<TDbContext, ConceptOneRequired> _oneRequired;
        private readonly IUpsertListService<TDbContext, ConceptProperty> _properties;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public ConceptUpsertService(ICacheService<Concept> cache, TDbContext database, ILogger<UpsertService<TDbContext, Concept>> logger, IUpsertListService<TDbContext, ConceptManyOptional> manyOptional, IUpsertListService<TDbContext, ConceptManyRequired> manyRequired, IUpsertListService<TDbContext, ConceptOneOptional> oneOptional, IUpsertListService<TDbContext, ConceptOneRequired> oneRequired, IUpsertListService<TDbContext, ConceptProperty> properties, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.Concepts)
        {
            CacheKey = record => $"{nameof(BusinessObjects)}.{nameof(Concept)}={record.NameId}:{record.SchemaId}";
            _manyOptional = manyOptional ?? throw new ArgumentNullException(nameof(manyOptional));
            _manyRequired = manyRequired ?? throw new ArgumentNullException(nameof(manyRequired));
            _oneOptional = oneOptional ?? throw new ArgumentNullException(nameof(oneOptional));
            _oneRequired = oneRequired ?? throw new ArgumentNullException(nameof(oneRequired));
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override Action<Concept, Concept> AssignChanges => (existing, given) =>
        {
            existing.Name = given.Name;
            existing.NameId = given.NameId;
            existing.Schema = given.Schema;
            existing.SchemaId = given.SchemaId;
            existing.ManyOptionalLeft = given.ManyOptionalLeft;
            existing.ManyOptionalRight = given.ManyOptionalRight;
            existing.ManyRequiredLeft = given.ManyRequiredLeft;
            existing.ManyRequiredRight = given.ManyRequiredRight;
            existing.OneOptionalLeft = given.OneOptionalLeft;
            existing.OneOptionalRight = given.OneOptionalRight;
            existing.OneRequiredLeft = given.OneRequiredLeft;
            existing.OneRequiredRight = given.OneRequiredRight;
            existing.Properties = given.Properties;
        };

        protected override async Task<Concept> AssignUpsertedDependents(Concept record)
        {
            var id = record.ConceptId;
            foreach (var item in record.ManyOptionalLeft ?? new List<ConceptManyOptional>()) item.Concept1Id = id;
            foreach (var item in record.ManyOptionalRight ?? new List<ConceptManyOptional>()) item.Concept2Id = id;
            foreach (var item in record.ManyRequiredLeft ?? new List<ConceptManyRequired>()) item.Concept1Id = id;
            foreach (var item in record.ManyRequiredRight ?? new List<ConceptManyRequired>()) item.Concept2Id = id;
            foreach (var item in record.OneOptionalLeft ?? new List<ConceptOneOptional>()) item.Concept1Id = id;
            foreach (var item in record.OneOptionalRight ?? new List<ConceptOneOptional>()) item.Concept2Id = id;
            foreach (var item in record.OneRequiredLeft ?? new List<ConceptOneRequired>()) item.Concept1Id = id;
            foreach (var item in record.OneRequiredRight ?? new List<ConceptOneRequired>()) item.Concept2Id = id;
            foreach (var item in record.Properties ?? new List<ConceptProperty>()) item.ConceptId = id;
            record.ManyOptionalLeft = await _manyOptional.UpsertAsync(record.ManyOptionalLeft);
            record.ManyOptionalRight = await _manyOptional.UpsertAsync(record.ManyOptionalRight);
            record.ManyRequiredLeft = await _manyRequired.UpsertAsync(record.ManyRequiredLeft);
            record.ManyRequiredRight = await _manyRequired.UpsertAsync(record.ManyRequiredRight);
            record.OneOptionalLeft = await _oneOptional.UpsertAsync(record.OneOptionalLeft);
            record.OneOptionalRight = await _oneOptional.UpsertAsync(record.OneOptionalRight);
            record.OneRequiredLeft = await _oneRequired.UpsertAsync(record.OneRequiredLeft);
            record.OneRequiredRight = await _oneRequired.UpsertAsync(record.OneRequiredRight);
            record.Properties = await _properties.UpsertAsync(record.Properties);
            return record;
        }

        protected override async Task<Concept> AssignUpsertedReferences(Concept record)
        {
            record.Name = await _strings.UpsertAsync(record.Name);
            record.NameId = record.Name?.AsciiStringReferenceId ?? record.NameId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Concept record)
        {
            yield return record.ManyOptionalLeft;
            yield return record.ManyOptionalRight;
            yield return record.ManyRequiredLeft;
            yield return record.ManyRequiredRight;
            yield return record.Name;
            yield return record.OneOptionalLeft;
            yield return record.OneOptionalRight;
            yield return record.OneRequiredLeft;
            yield return record.OneRequiredRight;
            yield return record.Properties;
            yield return record.Schema;
        }

        protected override Expression<Func<Concept, bool>> FindExisting(Concept record)
            => existing
                => existing.NameId == record.NameId
                && existing.SchemaId == record.SchemaId;
    }
}
