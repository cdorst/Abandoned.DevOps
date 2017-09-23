using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("ConstructorBaseInitializers", Schema = nameof(SourceCode))]
    public class ConstructorBaseInitializer
    {
        [Key]
        [ProtoMember(1)]
        public int ConstructorBaseInitializerId { get; set; }

        [ProtoMember(2)]
        public ArgumentList ArgumentList { get; set; }
        [ProtoMember(3)]
        public int ArgumentListId { get; set; }

        public ConstructorInitializerSyntax GetConstructorInitializerSyntax()
            => ConstructorInitializer(
                SyntaxKind.BaseConstructorInitializer,
                ArgumentList.GetArgumentListSyntax());
    }
}
