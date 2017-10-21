using DevOps.Abstractions.Core;
using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("PackageReferences", Schema = nameof(SourceCode))]
    public class PackageReference : IUniqueListRecord
    {
        [Key]
        [ProtoMember(1)]
        public int PackageReferenceId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(3)]
        public int NameId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference Version { get; set; }
        [ProtoMember(5)]
        public int VersionId { get; set; }

        public string GetPackageReference()
            => $"    <PackageReference Include=\"{Name.Value}\" Version=\"{Version.Value}\" />";
    }
}
