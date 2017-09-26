﻿using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class PropertyListUpsertService<TDbContext> : UpsertService<TDbContext, PropertyList>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public PropertyListUpsertService(ICacheService<PropertyList> cache, TDbContext database, ILogger<UpsertService<TDbContext, PropertyList>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.PropertyLists)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(Expression)}={record.ListIdentifierId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<PropertyList> AssignUpsertedReferences(PropertyList record)
        {
            record.ListIdentifier = await _strings.UpsertAsync(record.ListIdentifier);
            record.ListIdentifierId = record.ListIdentifier?.AsciiStringReferenceId ?? record.ListIdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(PropertyList record)
        {
            yield return record.PropertyListAssociations;
            yield return record.ListIdentifier;
        }

        protected override Expression<Func<PropertyList, bool>> FindExisting(PropertyList record)
            => existing => existing.ListIdentifierId == record.ListIdentifierId;
    }
}
