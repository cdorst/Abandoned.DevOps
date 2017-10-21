using DevOps.Abstractions.Core;
using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("PackageReferenceListAssociations", Schema = nameof(SourceCode))]
    public class PackageReferenceListAssociation : IUniqueListAssociation<PackageReference>
    {
        [Key]
        [ProtoMember(1)]
        public int PackageReferenceListAssociationId { get; set; }

        [ProtoMember(2)]
        public PackageReference PackageReference { get; set; }
        [ProtoMember(3)]
        public int PackageReferenceId { get; set; }

        [ProtoMember(4)]
        public PackageReferenceList PackageReferenceList { get; set; }
        [ProtoMember(5)]
        public int PackageReferenceListId { get; set; }

        public PackageReference GetRecord() => PackageReference;

        public void SetRecord(PackageReference record)
        {
            PackageReference = record ?? throw new ArgumentNullException(nameof(record));
            PackageReferenceId = PackageReference.PackageReferenceId;
        }
    }
}
