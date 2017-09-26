using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class ConstraintListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, ConstraintListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public ConstraintListAssociationUpsertService(ICacheService<ConstraintListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConstraintListAssociation>> logger)
            : base(cache, database, logger, database.ConstraintListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(ConstraintListAssociation)}={record.ConstraintId}:{record.ConstraintListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(ConstraintListAssociation record)
        {
            yield return record.Constraint;
            yield return record.ConstraintList;
        }

        protected override Expression<Func<ConstraintListAssociation, bool>> FindExisting(ConstraintListAssociation record)
            => existing
                => existing.ConstraintId == record.ConstraintId
                && existing.ConstraintListId == record.ConstraintListId;
    }
}
