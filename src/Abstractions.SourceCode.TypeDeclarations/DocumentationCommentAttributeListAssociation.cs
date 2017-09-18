using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("DocumentationCommentAttributeListAssociations", Schema = nameof(SourceCode))]
    public class DocumentationCommentAttributeListAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentAttributeListAssociationId { get; set; }

        [ProtoMember(2)]
        public DocumentationCommentAttribute DocumentationCommentAttribute { get; set; }
        [ProtoMember(3)]
        public int DocumentationCommentAttributeId { get; set; }

        [ProtoMember(4)]
        public DocumentationCommentAttributeList DocumentationCommentAttributeList { get; set; }
        [ProtoMember(5)]
        public int DocumentationCommentAttributeListId { get; set; }
    }
}
