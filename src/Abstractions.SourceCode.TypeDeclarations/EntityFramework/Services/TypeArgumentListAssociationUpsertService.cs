using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class TypeArgumentListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, TypeArgumentListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public TypeArgumentListAssociationUpsertService(ICacheService<TypeArgumentListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, TypeArgumentListAssociation>> logger)
            : base(cache, database, logger, database.TypeArgumentListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(TypeArgumentListAssociation)}={record.TypeArgumentId}:{record.TypeArgumentListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(TypeArgumentListAssociation record)
        {
            yield return record.TypeArgument;
            yield return record.TypeArgumentList;
        }

        protected override Expression<Func<TypeArgumentListAssociation, bool>> FindExisting(TypeArgumentListAssociation record)
            => existing
                => existing.TypeArgumentId == record.TypeArgumentId
                && existing.TypeArgumentListId == record.TypeArgumentListId;
    }
}
