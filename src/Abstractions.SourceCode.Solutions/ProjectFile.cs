using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("ProjectFiles", Schema = nameof(SourceCode))]
    public class ProjectFile
    {
        [Key]
        [ProtoMember(1)]
        public int ProjectFileId { get; set; }

        [ProtoMember(2)]
        public File File { get; set; }
        [ProtoMember(3)]
        public int FileId { get; set; }

        [ProtoMember(4)]
        public Project Project { get; set; }
        [ProtoMember(5)]
        public int ProjectId { get; set; }
    }
}
