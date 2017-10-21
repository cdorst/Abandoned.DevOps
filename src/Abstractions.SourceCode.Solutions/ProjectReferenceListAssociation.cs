using DevOps.Abstractions.Core;
using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("ProjectReferenceListAssociations", Schema = nameof(SourceCode))]
    public class ProjectReferenceListAssociation : IUniqueListAssociation<ProjectReference>
    {
        [Key]
        [ProtoMember(1)]
        public int ProjectReferenceListAssociationId { get; set; }

        [ProtoMember(2)]
        public ProjectReference ProjectReference { get; set; }
        [ProtoMember(3)]
        public int ProjectReferenceId { get; set; }

        [ProtoMember(4)]
        public ProjectReferenceList ProjectReferenceList { get; set; }
        [ProtoMember(5)]
        public int ProjectReferenceListId { get; set; }

        public ProjectReference GetRecord() => ProjectReference;

        public void SetRecord(ProjectReference record)
        {
            ProjectReference = record ?? throw new ArgumentNullException(nameof(record));
            ProjectReferenceId = ProjectReference.ProjectReferenceId;
        }
    }
}
