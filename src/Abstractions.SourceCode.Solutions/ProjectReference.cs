using DevOps.Abstractions.Core;
using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("ProjectReferences", Schema = nameof(SourceCode))]
    public class ProjectReference : IUniqueListRecord
    {
        [Key]
        [ProtoMember(1)]
        public int ProjectReferenceId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference RelativePath { get; set; }
        [ProtoMember(3)]
        public int RelativePathId { get; set; }

        public string GetProjectReference()
            => $"    <ProjectReference Include=\"{RelativePath.Value}\" />";
    }
}
