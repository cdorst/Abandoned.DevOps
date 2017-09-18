using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("DocumentationCommentAttributeLists", Schema = nameof(SourceCode))]
    public class DocumentationCommentAttributeList
    {
        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentAttributeListId { get; set; }

        [ProtoMember(2)]
        public List<DocumentationCommentAttributeListAssociation> DocumentationCommentAttributeListAssociations { get; set; }

        public static DocumentationCommentAttributeList FromXmlAttributeSyntaxList(IEnumerable<XmlAttributeSyntax> list)
            => new DocumentationCommentAttributeList
            {
                DocumentationCommentAttributeListAssociations = list
                    .Select(attribute => new DocumentationCommentAttributeListAssociation { DocumentationCommentAttribute = DocumentationCommentAttribute.FromXmlAttributeSyntax(attribute) })
                    .ToList()
            };

        public IEnumerable<XmlAttributeSyntax> GetXmlAttributeSyntaxList()
            => (DocumentationCommentAttributeListAssociations.Count == 1)
            ? (IEnumerable<XmlAttributeSyntax>)SingletonList(
                    DocumentationCommentAttributeListAssociations.First()
                        .DocumentationCommentAttribute.GetXmlAttributeSyntax())
            : DocumentationCommentAttributeListAssociations
                .Select(association => association.DocumentationCommentAttribute.GetXmlAttributeSyntax())
                .ToList();
    }
}
