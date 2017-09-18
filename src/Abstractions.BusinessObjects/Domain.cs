using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.BusinessObjects
{
    [ProtoContract]
    [Table("Domains", Schema = nameof(BusinessObjects))]
    public class Domain
    {
        [Key]
        [ProtoMember(1)]
        public int DomainId { get; set; }
        
        [ProtoMember(2)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(3)]
        public int NameId { get; set; }

        [ProtoMember(4)]
        public System System { get; set; }
        [ProtoMember(5)]
        public int SystemId { get; set; }

        [ProtoMember(6)]
        public List<Schema> Schemas { get; set; }
    }
}
