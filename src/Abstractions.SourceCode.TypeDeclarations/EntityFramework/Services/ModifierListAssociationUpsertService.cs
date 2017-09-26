using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class ModifierListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, ModifierListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public ModifierListAssociationUpsertService(ICacheService<ModifierListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, ModifierListAssociation>> logger)
            : base(cache, database, logger, database.ModifierListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(ModifierListAssociation)}={record.SyntaxTokenId}:{record.ModifierListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(ModifierListAssociation record)
        {
            yield return record.SyntaxToken;
            yield return record.ModifierList;
        }

        protected override Expression<Func<ModifierListAssociation, bool>> FindExisting(ModifierListAssociation record)
            => existing
                => existing.SyntaxTokenId == record.SyntaxTokenId
                && existing.ModifierListId == record.ModifierListId;
    }
}
