using Microsoft.CodeAnalysis;
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
    [Table("UsingDirectiveLists", Schema = nameof(SourceCode))]
    public class UsingDirectiveList
    {
        [Key]
        [ProtoMember(1)]
        public int UsingDirectiveListId { get; set; }

        [ProtoMember(2)]
        public List<UsingDirectiveListAssociation> UsingDirectiveListAssociations { get; set; }

        public SyntaxList<UsingDirectiveSyntax> GetUsingDirectiveListSyntax()
            => UsingDirectiveListAssociations.Count == 1
            ? SingletonList(
                UsingDirectiveListAssociations
                    .First()
                    .UsingDirective
                    .GetUsingDirectiveSyntax())
            : List(
                UsingDirectiveListAssociations
                    .Select(s => s.UsingDirective.GetUsingDirectiveSyntax()));
    }
}
