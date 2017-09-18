using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies.Mapping
{
    public class ConceptMappingService : MappingService<ConceptDefinition, Concept>
    {
        public ConceptMappingService(ILogger<MappingService<ConceptDefinition, Concept>> logger, IMappingService<PropertyDefinition, ConceptProperty> mappingService) : base(logger)
        {
            Result = (input, parentId) => new Concept
            {
                SchemaId = parentId,
                Name = new AsciiStringReference(input.Concept),
                Properties = input.Properties?.Select(p => mappingService.Map(p)).ToList()
            };
        }
    }
}
