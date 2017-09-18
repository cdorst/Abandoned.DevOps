using System.Collections.Generic;

namespace DevOps.Abstractions.BusinessObjects.Simplified
{
    public class DomainDefinition
    {
        public string Domain { get; set; }
        public List<SchemaDefinition> Schemas { get; set; }
    }
}
