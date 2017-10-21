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
    [Table("PackageReferenceLists", Schema = nameof(SourceCode))]
    public class PackageReferenceList : IUniqueList<PackageReference, PackageReferenceListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int PackageReferenceListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<PackageReferenceListAssociation> PackageReferenceListAssociations { get; set; }

        public string GetPackageReferences() => string.Join(Environment.NewLine, PackageReferenceListAssociations.Select(p => p.PackageReference.GetPackageReference()));

        public List<PackageReferenceListAssociation> GetAssociations() => PackageReferenceListAssociations;

        public void SetRecords(List<PackageReference> records)
        {
            for (int i = 0; i < PackageReferenceListAssociations.Count; i++)
            {
                PackageReferenceListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.PackageReferenceId)));
        }
    }
}
