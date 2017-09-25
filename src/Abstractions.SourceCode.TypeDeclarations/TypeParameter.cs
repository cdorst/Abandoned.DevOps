using DevOps.Abstractions.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("TypeParameters", Schema = nameof(SourceCode))]
    public class TypeParameter : IUniqueListRecord
    {
        [Key]
        [ProtoMember(1)]
        public int TypeParameterId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public TypeParameterSyntax GetTypeParameterSyntax()
            => TypeParameter(Identifier.GetSyntaxToken());
    }
}
