using System.Collections.Generic;

namespace DevOps.Abstractions.BusinessObjects.Simplified
{
    public class SystemDefinition
    {
        public string System { get; set; }
        public List<DomainDefinition> Domains { get; set; }
    }
}
