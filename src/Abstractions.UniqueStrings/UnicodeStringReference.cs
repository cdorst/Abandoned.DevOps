using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.UniqueStrings
{
    [ProtoContract]
    [Table("UnicodeStringReferences", Schema = nameof(UniqueStrings))]
    public class UnicodeStringReference
    {
        public UnicodeStringReference() { }
        public UnicodeStringReference(string input) { Value = input; }
        [Key]
        [ProtoMember(1)]
        public int UnicodeStringReferenceId { get; set; }
        [ProtoMember(2)]
        public string Value { get; set; }
    }
}
