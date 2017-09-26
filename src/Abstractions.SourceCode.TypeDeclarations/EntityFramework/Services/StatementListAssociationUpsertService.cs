﻿using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class StatementListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, StatementListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public StatementListAssociationUpsertService(ICacheService<StatementListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, StatementListAssociation>> logger)
            : base(cache, database, logger, database.StatementListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(StatementListAssociation)}={record.StatementId}:{record.StatementListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(StatementListAssociation record)
        {
            yield return record.Statement;
            yield return record.StatementList;
        }

        protected override Expression<Func<StatementListAssociation, bool>> FindExisting(StatementListAssociation record)
            => existing
                => existing.StatementId == record.StatementId
                && existing.StatementListId == record.StatementListId;
    }
}
