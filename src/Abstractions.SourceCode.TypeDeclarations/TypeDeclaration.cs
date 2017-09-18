using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("TypeDeclaration", Schema = nameof(SourceCode))]
    public class TypeDeclaration
    {
        [Key]
        [ProtoMember(1)]
        public int TypeDeclarationId { get; set; }

        [ProtoMember(2)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(3)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(4)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(5)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(6)]
        public Namespace Namespace { get; set; }
        [ProtoMember(7)]
        public int NamespaceId { get; set; }

        [ProtoMember(8)]
        public TypeSyntax TypeSyntax { get; set; }
        [ProtoMember(9)]
        public int TypeSyntaxId { get; set; }
    }
}
