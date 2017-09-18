using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("Namespaces", Schema = nameof(SourceCode))]
    public class Namespace
    {
        [Key]
        [ProtoMember(1)]
        public int NamespaceId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public NamespaceDeclarationSyntax GetNamespaceDeclaration(SyntaxNode typeDeclaration)
            => NamespaceDeclaration(Identifier.GetNameSyntax())
                .WithMembers(SingletonList(typeDeclaration));

        public UsingDirectiveSyntax GetUsingDirective()
            => UsingDirective(Identifier.GetNameSyntax());
    }
}
