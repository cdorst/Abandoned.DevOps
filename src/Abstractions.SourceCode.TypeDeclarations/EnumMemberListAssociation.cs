using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("EnumMemberListAssociations", Schema = nameof(SourceCode))]
    public class EnumMemberListAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int EnumMemberListAssociationId { get; set; }

        [ProtoMember(2)]
        public EnumMemberList EnumMemberList { get; set; }
        [ProtoMember(3)]
        public int EnumMemberListId { get; set; }

        [ProtoMember(4)]
        public EnumMember EnumMember { get; set; }
        [ProtoMember(5)]
        public int EnumMemberId { get; set; }
    }
}
