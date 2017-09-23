using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("Constraints", Schema = nameof(SourceCode))]
    public class Constraint
    {
        [Key]
        [ProtoMember(1)]
        public int ConstraintId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public TypeParameterConstraintSyntax GetTypeParameterConstraintSyntax()
            => Identifier.Name.Value == "class"
            ? ClassOrStructConstraint(SyntaxKind.ClassConstraint)
            : Identifier.Name.Value == "struct"
            ? ClassOrStructConstraint(SyntaxKind.StructConstraint)
            : (TypeParameterConstraintSyntax)TypeConstraint(
                Identifier.GetIdentifierNameSyntax());
    }
}
