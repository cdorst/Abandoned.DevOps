using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class ConstraintClauseListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, ConstraintClauseListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public ConstraintClauseListAssociationUpsertService(ICacheService<ConstraintClauseListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConstraintClauseListAssociation>> logger)
            : base(cache, database, logger, database.ConstraintClauseListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(ConstraintClauseListAssociation)}={record.ConstraintClauseId}:{record.ConstraintClauseListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(ConstraintClauseListAssociation record)
        {
            yield return record.ConstraintClause;
            yield return record.ConstraintClauseList;
        }

        protected override Expression<Func<ConstraintClauseListAssociation, bool>> FindExisting(ConstraintClauseListAssociation record)
            => existing
                => existing.ConstraintClauseId == record.ConstraintClauseId
                && existing.ConstraintClauseListId == record.ConstraintClauseListId;
    }
}
