using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("TargetFrameworks", Schema = nameof(SourceCode))]
    public class TargetFramework
    {
        [Key]
        [ProtoMember(1)]
        public int TargetFrameworkId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(3)]
        public int NameId { get; set; }

        public string GetName() => Name.Value;
    }
}
