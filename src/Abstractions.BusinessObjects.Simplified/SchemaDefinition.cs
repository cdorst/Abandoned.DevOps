using System.Collections.Generic;

namespace DevOps.Abstractions.BusinessObjects.Simplified
{
    public class SchemaDefinition
    {
        public string Schema { get; set; }
        public List<ConceptDefinition> Concepts { get; set; }
    }
}
