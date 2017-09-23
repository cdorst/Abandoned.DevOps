using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    public interface ISortableMemberDeclaration
    {
        ModifierList ModifierList { get; set; }
        Identifier Identifier { get; set; }
        MemberDeclarationSyntax GetMemberDeclarationSyntax();
    }
}
