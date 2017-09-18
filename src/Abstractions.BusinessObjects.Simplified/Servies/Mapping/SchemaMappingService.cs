using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies.Mapping
{
    public class SchemaMappingService : MappingService<SchemaDefinition, Schema>
    {
        public SchemaMappingService(ILogger<MappingService<SchemaDefinition, Schema>> logger, IMappingService<ConceptDefinition, Concept> mappingService) : base(logger)
        {
            Result = (input, parentId) => new Schema
            {
                DomainId = parentId,
                Name = new AsciiStringReference(input.Schema),
                Concepts = input.Concepts?.Select(c => mappingService.Map(c)).ToList()
            };
        }
    }
}
