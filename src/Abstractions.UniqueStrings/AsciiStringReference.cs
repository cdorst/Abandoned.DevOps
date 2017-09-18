using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.UniqueStrings
{
    [ProtoContract]
    [Table("AsciiStringReferences", Schema = nameof(UniqueStrings))]
    public class AsciiStringReference
    {
        public AsciiStringReference() { }
        public AsciiStringReference(string input) { Value = input; }
        [Key]
        [ProtoMember(1)]
        public int AsciiStringReferenceId { get; set; }
        [Column(TypeName = "varchar(450)")]
        [ProtoMember(2)]
        public string Value { get; set; }
    }
}
