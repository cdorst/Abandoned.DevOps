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
    [ProtoContract]
    [Table("AccessorLists", Schema = nameof(SourceCode))]
    public class AccessorList
    {
        [Key]
        [ProtoMember(1)]
        public int AccessorListId { get; set; }

        [ProtoMember(2)]
        public List<AccessorListAssociation> AccessorListAssociations { get; set; }

        public AccessorListSyntax GetAccessorListSyntax()
            => AccessorListAssociations.Count == 1
            ? AccessorList(
                SingletonList(
                    AccessorListAssociations
                        .First()
                        .Accessor
                        .GetAccessorDeclarationSyntax()))
            : AccessorList(
                List(
                    AccessorListAssociations
                        .OrderBy(a => a.Accessor.SyntaxToken.SyntaxKind == SyntaxKind.GetAccessorDeclaration ? 0 : 1)
                        .Select(a => a.Accessor.GetAccessorDeclarationSyntax())));
    }
}
