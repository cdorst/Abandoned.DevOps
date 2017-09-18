using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    /// <remarks>Each instance represents a collection of attribute lists. Each attribute list contains a single attribute</remarks>
    [ProtoContract]
    [Table("AttributeListCollections", Schema = nameof(SourceCode))]
    public class AttributeListCollection
    {
        [Key]
        [ProtoMember(1)]
        public int AttributeListCollectionId { get; set; }

        [ProtoMember(2)]
        public List<AttributeListCollectionAssociation> AttributeLists { get; set; }

        public SyntaxList<AttributeListSyntax> GetAttributeListSyntaxList(DocumentationCommentList documentation = null)
        {
            var attributes = AttributeLists
                .Select(attr => AttributeList(SingletonSeparatedList(attr.Attribute.GetAttributeSyntax())))
                .ToArray();
            return (documentation == null) ? List(attributes) 
                : GetListWithDocumentation(documentation, attributes);
        }

        private static SyntaxList<AttributeListSyntax> GetListWithDocumentation(DocumentationCommentList documentation, AttributeListSyntax[] attributes)
        {
            var list = new List<AttributeListSyntax>();
            for (int i = 0; i < attributes.Length; i++)
            {
                var attribute = attributes[i];
                if (i == 0)
                {
                    attribute = attribute.WithOpenBracketToken(
                        Token(
                            TriviaList(
                                Trivia(
                                    documentation.GetDocumentationCommentTriviaSyntax())),
                            SyntaxKind.OpenBracketToken,
                            TriviaList()));
                }
                list.Add(attribute);
            }
            return List(list.ToArray());
        }
    }
}
