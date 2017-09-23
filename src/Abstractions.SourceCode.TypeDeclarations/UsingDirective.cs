using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("UsingDirectives", Schema = nameof(SourceCode))]
    public class UsingDirective
    {
        [Key]
        [ProtoMember(1)]
        public int UsingDirectiveId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public UsingDirectiveSyntax GetUsingDirectiveSyntax()
            => UsingDirective(Identifier.GetNameSyntax());
    }
}
