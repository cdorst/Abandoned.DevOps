using DevOps.Abstractions.Core;
using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("ProjectReferenceList", Schema = nameof(SourceCode))]
    public class ProjectReferenceList : IUniqueList<ProjectReference, ProjectReferenceListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int ProjectReferenceListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<ProjectReferenceListAssociation> ProjectReferenceListAssociations { get; set; }

        public string GetProjectReferences() => string.Join(Environment.NewLine, ProjectReferenceListAssociations.Select(p => p.ProjectReference.GetProjectReference()));

        public List<ProjectReferenceListAssociation> GetAssociations() => ProjectReferenceListAssociations;

        public void SetRecords(List<ProjectReference> records)
        {
            for (int i = 0; i < ProjectReferenceListAssociations.Count; i++)
            {
                ProjectReferenceListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.ProjectReferenceId)));
        }
    }
}
