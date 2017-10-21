using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("PackageOptions", Schema = nameof(SourceCode))]
    public class PackageOptions
    {
        [Key]
        [ProtoMember(1)]
        public int PackageOptionsId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Authors { get; set; }
        [ProtoMember(3)]
        public int AuthorsId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference Description { get; set; }
        [ProtoMember(5)]
        public int DescriptionId { get; set; }

        [ProtoMember(6)]
        public AsciiStringReference TargetFramework { get; set; }
        [ProtoMember(7)]
        public int TargetFrameworkId { get; set; }

        public string GetPackageOptions()
            => new StringBuilder("    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>")
                .AppendLine($"    <Description>{Description.Value}</Description>")
                .AppendLine($"    <Author>{Authors.Value}</Author>")
                .ToString();
    }
}
