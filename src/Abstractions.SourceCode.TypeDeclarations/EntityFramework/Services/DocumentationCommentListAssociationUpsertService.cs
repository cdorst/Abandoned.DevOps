using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class DocumentationCommentListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, DocumentationCommentListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public DocumentationCommentListAssociationUpsertService(ICacheService<DocumentationCommentListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, DocumentationCommentListAssociation>> logger)
            : base(cache, database, logger, database.DocumentationCommentListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(DocumentationCommentListAssociation)}={record.DocumentationCommentId}:{record.DocumentationCommentListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(DocumentationCommentListAssociation record)
        {
            yield return record.DocumentationComment;
            yield return record.DocumentationCommentList;
        }

        protected override Expression<Func<DocumentationCommentListAssociation, bool>> FindExisting(DocumentationCommentListAssociation record)
            => existing
                => existing.DocumentationCommentId == record.DocumentationCommentId
                && existing.DocumentationCommentListId == record.DocumentationCommentListId;
    }
}
