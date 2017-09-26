using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class DocumentationCommentAttributeListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, DocumentationCommentAttributeListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public DocumentationCommentAttributeListAssociationUpsertService(ICacheService<DocumentationCommentAttributeListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, DocumentationCommentAttributeListAssociation>> logger)
            : base(cache, database, logger, database.DocumentationCommentAttributeListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(DocumentationCommentAttributeListAssociation)}={record.DocumentationCommentAttributeId}:{record.DocumentationCommentAttributeListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(DocumentationCommentAttributeListAssociation record)
        {
            yield return record.DocumentationCommentAttribute;
            yield return record.DocumentationCommentAttributeList;
        }

        protected override Expression<Func<DocumentationCommentAttributeListAssociation, bool>> FindExisting(DocumentationCommentAttributeListAssociation record)
            => existing
                => existing.DocumentationCommentAttributeId == record.DocumentationCommentAttributeId
                && existing.DocumentationCommentAttributeListId == record.DocumentationCommentAttributeListId;
    }
}
