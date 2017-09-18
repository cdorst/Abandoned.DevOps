using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.UniqueStrings
{
    [ProtoContract]
    [Table("UnicodeMaxStringReferences", Schema = nameof(UniqueStrings))]
    public class UnicodeMaxStringReference
    {
        public UnicodeMaxStringReference() { }
        public UnicodeMaxStringReference(string input) { Value = input; }
        [Key]
        [ProtoMember(1)]
        public int UnicodeMaxStringReferenceId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Hash { get; set; }
        [ProtoMember(3)]
        public int HashId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [ProtoMember(4)]
        public string Value { get; set; }
    }
}
