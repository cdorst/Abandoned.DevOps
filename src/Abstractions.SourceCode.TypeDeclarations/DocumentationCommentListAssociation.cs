using DevOps.Abstractions.Core;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("DocumentationCommentListAssociations", Schema = nameof(SourceCode))]
    public class DocumentationCommentListAssociation : IUniqueListAssociation<DocumentationComment>
    {
        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentListAssociationId { get; set; }

        [ProtoMember(2)]
        public DocumentationComment DocumentationComment { get; set; }
        [ProtoMember(3)]
        public int DocumentationCommentId { get; set; }

        [ProtoMember(4)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(5)]
        public int DocumentationCommentListId { get; set; }

        public DocumentationComment GetRecord() => DocumentationComment;

        public void SetRecord(DocumentationComment record)
        {
            DocumentationComment = record;
            DocumentationCommentId = DocumentationComment.DocumentationCommentId;
        }
    }
}
