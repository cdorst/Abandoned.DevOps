using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.BusinessObjects
{
    [ProtoContract]
    [Table("Concepts", Schema = nameof(BusinessObjects))]
    public class Concept
    {
        [Key]
        [ProtoMember(1)]
        public int ConceptId { get; set; }
        [ProtoMember(2)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(3)]
        public int NameId { get; set; }
        [ProtoMember(4)]
        public Schema Schema { get; set; }
        [ProtoMember(5)]
        public int SchemaId { get; set; }
        [ProtoMember(6)]
        public List<ConceptManyOptional> ManyOptionalLeft { get; set; }
        [ProtoMember(7)]
        public List<ConceptManyOptional> ManyOptionalRight { get; set; }
        [ProtoMember(8)]
        public List<ConceptManyRequired> ManyRequiredLeft { get; set; }
        [ProtoMember(9)]
        public List<ConceptManyRequired> ManyRequiredRight { get; set; }
        [ProtoMember(10)]
        public List<ConceptOneOptional> OneOptionalLeft { get; set; }
        [ProtoMember(11)]
        public List<ConceptOneOptional> OneOptionalRight { get; set; }
        [ProtoMember(12)]
        public List<ConceptOneRequired> OneRequiredLeft { get; set; }
        [ProtoMember(13)]
        public List<ConceptOneRequired> OneRequiredRight { get; set; }
        [ProtoMember(14)]
        public List<ConceptProperty> Properties { get; set; }
    }
}
