using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies.Mapping
{
    public class PropertyMappingService : MappingService<PropertyDefinition, ConceptProperty>
    {
        public PropertyMappingService(ILogger<MappingService<PropertyDefinition, ConceptProperty>> logger) : base(logger)
        {
            Result = (input, parentId) => new ConceptProperty
            {
                ConceptId = parentId,
                ImportNamespace = string.IsNullOrWhiteSpace(input.TypeImportNamespace) ? null : new AsciiStringReference(input.TypeImportNamespace),
                Name = new AsciiStringReference(input.Property),
                Type = new AsciiStringReference(input.Type)
            };
        }
    }
}
