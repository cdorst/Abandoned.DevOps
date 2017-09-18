using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies.Mapping
{
    public class SystemMappingService : MappingService<SystemDefinition, System>
    {
        public SystemMappingService(ILogger<MappingService<SystemDefinition, System>> logger, IMappingService<DomainDefinition, Domain> mappingService) : base(logger)
        {
            Result = (input, parentId) => new System
            {
                Name = new AsciiStringReference(input.System),
                Domains = input.Domains?.Select(d => mappingService.Map(d)).ToList()
            };
        }
    }
}
