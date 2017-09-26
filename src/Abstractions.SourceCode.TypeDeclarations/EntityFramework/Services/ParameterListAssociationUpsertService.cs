using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework.Services
{
    public class ParameterListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, ParameterListAssociation>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public ParameterListAssociationUpsertService(ICacheService<ParameterListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, ParameterListAssociation>> logger)
            : base(cache, database, logger, database.ParameterListAssociations)
        {
            CacheKey = record => $"{nameof(SourceCode)}.{nameof(ParameterListAssociation)}={record.ParameterId}:{record.ParameterListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(ParameterListAssociation record)
        {
            yield return record.Parameter;
            yield return record.ParameterList;
        }

        protected override Expression<Func<ParameterListAssociation, bool>> FindExisting(ParameterListAssociation record)
            => existing
                => existing.ParameterId == record.ParameterId
                && existing.ParameterListId == record.ParameterListId;
    }
}
