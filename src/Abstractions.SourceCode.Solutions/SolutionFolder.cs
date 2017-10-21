using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("SolutionFolders", Schema = nameof(SourceCode))]
    public class SolutionFolder
    {
        [Key]
        [ProtoMember(1)]
        public int SolutionFolderId { get; set; }

        [ProtoMember(2)]
        public Guid? Guid { get; set; }

        [ProtoMember(3)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(4)]
        public int NameId { get; set; }

        [ProtoMember(5)]
        public Solution Solution { get; set; }
        [ProtoMember(6)]
        public int SolutionId { get; set; }

        [ProtoMember(7)]
        public List<Project> Projects { get; set; }
        [ProtoMember(8)]
        public List<SolutionFile> SolutionFiles { get; set; }

        public string GetSlnProjectDeclaration()
            => SlnDeclarations.GetProjectDeclaration(SlnGuidTypes.Folder,
                name: Name.Value,
                path: Name.Value,
                guid: Guid.Value);
    }
}
