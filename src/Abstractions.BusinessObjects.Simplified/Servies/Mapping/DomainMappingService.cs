using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies.Mapping
{
    public class DomainMappingService : MappingService<DomainDefinition, Domain>
    {
        public DomainMappingService(ILogger<MappingService<DomainDefinition, Domain>> logger, IMappingService<SchemaDefinition, Schema> mappingService) : base(logger)
        {
            Result = (input, parentId) => new Domain
            {
                SystemId = parentId,
                Name = new AsciiStringReference(input.Domain),
                Schemas = input.Schemas?.Select(s => mappingService.Map(s)).ToList()
            };
        }
    }
}
