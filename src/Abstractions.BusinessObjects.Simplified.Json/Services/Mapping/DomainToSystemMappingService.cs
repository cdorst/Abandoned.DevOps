using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Json.Services.Mapping
{
    public class DomainToSystemMappingService : ParentMappingService<DomainDefinition, SystemDefinition>
    {
        public DomainToSystemMappingService(
            ILogger<ParentMappingService<DomainDefinition, SystemDefinition>> logger,
            IOptions<JsonBusinessObjectsOptions> options)
            : base(logger)
        {
            var system = (options?.Value ?? new JsonBusinessObjectsOptions()).System;
            Result = domains => new SystemDefinition { Domains = domains, System = system };
        }
    }
}
