using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.BusinessObjects
{
    [ProtoContract]
    [Table("Schemas", Schema = nameof(BusinessObjects))]
    public class Schema
    {
        [Key]
        [ProtoMember(1)]
        public int SchemaId { get; set; }

        [ProtoMember(2)]
        public Domain Domain { get; set; }
        [ProtoMember(3)]
        public int DomainId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(5)]
        public int NameId { get; set; }

        [ProtoMember(6)]
        public List<Concept> Concepts { get; set; }
    }
}
