using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class SyntaxTokenUpsertService<TDbContext> : UpsertService<TDbContext, SyntaxToken>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public SyntaxTokenUpsertService(ICacheService<SyntaxToken> cache, TDbContext database, ILogger<UpsertService<TDbContext, SyntaxToken>> logger)
            : base(cache, database, logger, database.SyntaxTokens)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(SyntaxToken)}={record.SyntaxKind}";
        }

        protected override Expression<Func<SyntaxToken, bool>> FindExisting(SyntaxToken record)
            => existing => existing.SyntaxKind == record.SyntaxKind;
    }
}
