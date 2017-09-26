using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.UniqueStrings
{
    [ProtoContract]
    [Table("AsciiMaxStringReferences", Schema = nameof(UniqueStrings))]
    public class AsciiMaxStringReference
    {
        public AsciiMaxStringReference() { }
        public AsciiMaxStringReference(string input) { Value = input; }
        [Key]
        [ProtoMember(1)]
        public int AsciiMaxStringReferenceId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Hash { get; set; }
        [ProtoMember(3)]
        public int HashId { get; set; }

        [Column(TypeName = "varchar(max)")]
        [ProtoMember(4)]
        public string Value { get; set; }
    }
}
