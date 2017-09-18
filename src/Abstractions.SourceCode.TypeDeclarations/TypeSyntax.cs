using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("TypeSyntax", Schema = nameof(SourceCode))]
    public class TypeSyntax
    {
        [Key]
        [ProtoMember(1)]
        public int TypeSyntaxId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax GetTypeSyntax()
            => ParseTypeName(Identifier.Name.Value);
    }
}
