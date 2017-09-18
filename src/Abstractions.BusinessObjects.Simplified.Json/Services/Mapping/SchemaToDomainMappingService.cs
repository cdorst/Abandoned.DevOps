using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Json.Services.Mapping
{
    public class SchemaToDomainMappingService : ParentMappingService<SchemaDefinition, DomainDefinition>
    {
        public SchemaToDomainMappingService(
            ILogger<ParentMappingService<SchemaDefinition, DomainDefinition>> logger,
            IOptions<JsonBusinessObjectsOptions> options)
            : base(logger)
        {
            var domain = (options?.Value ?? new JsonBusinessObjectsOptions()).Domain;
            Result = schemas => new DomainDefinition { Domain = domain, Schemas = schemas };
        }
    }
}
