using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("UsingDirectiveListAssociations", Schema = nameof(SourceCode))]
    public class UsingDirectiveListAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int UsingDirectiveListAssociationId { get; set; }

        [ProtoMember(2)]
        public UsingDirective UsingDirective { get; set; }
        [ProtoMember(3)]
        public int UsingDirectiveId { get; set; }

        [ProtoMember(4)]
        public UsingDirectiveList UsingDirectiveList { get; set; }
        [ProtoMember(5)]
        public int UsingDirectiveListId { get; set; }
    }
}
