using System.Collections.Generic;

namespace DevOps.Abstractions.BusinessObjects.Simplified
{
    public class ConceptDefinition
    {
        public string Concept { get; set; }
        public List<string> HasOne { get; set; }
        public List<string> HasZeroOrOne { get; set; }
        public List<string> HasManyToMany { get; set; }
        public List<string> HasZeroToMany { get; set; }
        public List<PropertyDefinition> Properties { get; set; }
    }
}
