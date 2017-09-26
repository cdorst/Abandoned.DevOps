using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class UsingDirectiveListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, UsingDirectiveListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public UsingDirectiveListAssociationUpsertService(ICacheService<UsingDirectiveListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, UsingDirectiveListAssociation>> logger)
            : base(cache, database, logger, database.UsingDirectiveListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(UsingDirectiveListAssociation)}={record.UsingDirectiveId}:{record.UsingDirectiveListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(UsingDirectiveListAssociation record)
        {
            yield return record.UsingDirective;
            yield return record.UsingDirectiveList;
        }

        protected override Expression<Func<UsingDirectiveListAssociation, bool>> FindExisting(UsingDirectiveListAssociation record)
            => existing
                => existing.UsingDirectiveId == record.UsingDirectiveId
                && existing.UsingDirectiveListId == record.UsingDirectiveListId;
    }
}
