using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("Solutions", Schema = nameof(SourceCode))]
    public class Solution
    {
        [Key]
        [ProtoMember(1)]
        public int SolutionId { get; set; }

        [ProtoMember(2)]
        public Guid? Guid { get; set; }

        [ProtoMember(3)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(4)]
        public int NameId { get; set; }

        [ProtoMember(5)]
        public List<NuGetFeed> NuGetFeeds { get; set; }
        [ProtoMember(6)]
        public List<SolutionFolder> SolutionFolders { get; set; }
    }
}
