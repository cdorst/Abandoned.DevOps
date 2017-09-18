using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.BusinessObjects
{
    [Table("ConceptProperties", Schema = nameof(BusinessObjects))]
    [ProtoContract]
    public class ConceptProperty
    {
        [Key]
        [ProtoMember(1)]
        public int ConceptPropertyId { get; set; }

        [ProtoMember(2)]
        public Concept Concept { get; set; }
        [ProtoMember(3)]
        public int ConceptId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference ImportNamespace { get; set; }
        [ProtoMember(5)]
        public int ImportNamespaceId { get; set; }

        [ProtoMember(6)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(7)]
        public int NameId { get; set; }

        [ProtoMember(8)]
        public AsciiStringReference Type { get; set; }
        [ProtoMember(9)]
        public int TypeId { get; set; }
    }
}
