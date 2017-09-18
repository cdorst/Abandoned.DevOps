using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.BusinessObjects
{
    [ProtoContract]
    [Table("ConceptOneRequireds", Schema = nameof(BusinessObjects))]
    public class ConceptOneRequired
    {
        [Key]
        [ProtoMember(1)]
        public int ConceptOneRequiredId { get; set; }

        [ProtoMember(2)]
        public Concept Concept1 { get; set; }
        [ProtoMember(3)]
        public int Concept1Id { get; set; }

        [ProtoMember(4)]
        public Concept Concept2 { get; set; }
        [ProtoMember(5)]
        public int Concept2Id { get; set; }
    }
}
