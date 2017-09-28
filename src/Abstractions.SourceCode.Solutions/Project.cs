using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("Projects", Schema = nameof(SourceCode))]
    public class Project
    {
        [Key]
        [ProtoMember(1)]
        public int ProjectId { get; set; }

        [ProtoMember(2)]
        public Guid? Guid { get; set; }

        [ProtoMember(3)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(4)]
        public int NameId { get; set; }

        [ProtoMember(5)]
        public AsciiStringReference PathRelativeToSolution { get; set; }
        [ProtoMember(6)]
        public int PathRelativeToSolutionId { get; set; }

        [ProtoMember(7)]
        public SolutionFolder SolutionFolder { get; set; }
        [ProtoMember(8)]
        public int SolutionFolderId { get; set; }

        [ProtoMember(9)]
        public List<ProjectFile> ProjectFiles { get; set; }

        public string GetNamespace()
            => $"{SolutionFolder.Solution.Name.Value}.{Name.Value}";
    }
}
