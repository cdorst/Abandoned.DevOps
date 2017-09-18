using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("Attributes", Schema = nameof(SourceCode))]
    public class Attribute
    {
        [Key]
        [ProtoMember(1)]
        public int AttributeID { get; set; }
        
        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }
        
        [ProtoMember(4)]
        public AttributeArgumentListExpression AttributeArgumentListExpression { get; set; }
        [ProtoMember(5)]
        public int? AttributeArgumentListExpressionId { get; set; }

        public AttributeSyntax GetAttributeSyntax()
            => AttributeArgumentListExpression != null
                ? Attribute(Identifier.GetNameSyntax(), AttributeArgumentListExpression.GetAttributeArgumentListSyntax())
                : Attribute(Identifier.GetNameSyntax());
    }
}
