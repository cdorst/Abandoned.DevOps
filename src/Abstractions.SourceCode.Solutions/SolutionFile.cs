using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("SolutionFiles", Schema = nameof(SourceCode))]
    public class SolutionFile
    {
        [Key]
        [ProtoMember(1)]
        public int SolutionFileId { get; set; }

        [ProtoMember(2)]
        public Guid? Guid { get; set; }

        [ProtoMember(3)]
        public File File { get; set; }
        [ProtoMember(4)]
        public int FileId { get; set; }

        [ProtoMember(5)]
        public SolutionFolder SolutionFolder { get; set; }
        [ProtoMember(6)]
        public int SolutionFolderId { get; set; }
    }

    [ProtoContract]
    public class NuGetConfigSolutionFile : SolutionFile
    {


        [ProtoMember(7)]
        public NuGetFeed NuGetFeed { get; set; }
        [ProtoMember(8)]
        public int NuGetFeedId { get; set; }
    }
}
