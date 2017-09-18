using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Json.Services.Mapping
{
    public class SchemaToSystemMappingService : ParentMappingService<SchemaDefinition, SystemDefinition>
    {
        private readonly IParentMappingService<SchemaDefinition, DomainDefinition> _mappingService;

        public SchemaToSystemMappingService(
            ILogger<ParentMappingService<SchemaDefinition, SystemDefinition>> logger,
            IParentMappingService<SchemaDefinition, DomainDefinition> mappingService,
            IOptions<JsonBusinessObjectsOptions> options)
            : base(logger)
        {
            _mappingService = mappingService;
            var system = (options?.Value ?? new JsonBusinessObjectsOptions()).System;
            Result = schemas => new SystemDefinition
            {
                Domains =  new List<DomainDefinition> { _mappingService.Map(schemas) },
                System = system
            };
        }
    }
}
