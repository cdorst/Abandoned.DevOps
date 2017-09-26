using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class MethodListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, MethodListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public MethodListAssociationUpsertService(ICacheService<MethodListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, MethodListAssociation>> logger)
            : base(cache, database, logger, database.MethodListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(MethodListAssociation)}={record.MethodId}:{record.MethodListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(MethodListAssociation record)
        {
            yield return record.Method;
            yield return record.MethodList;
        }

        protected override Expression<Func<MethodListAssociation, bool>> FindExisting(MethodListAssociation record)
            => existing
                => existing.MethodId == record.MethodId
                && existing.MethodListId == record.MethodListId;
    }
}
