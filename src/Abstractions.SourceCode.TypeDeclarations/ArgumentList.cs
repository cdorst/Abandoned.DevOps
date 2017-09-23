using Microsoft.CodeAnalysis;
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
    [Table("ArgumentLists", Schema = nameof(SourceCode))]
    public class ArgumentList
    {
        [Key]
        [ProtoMember(1)]
        public int ArgumentListId { get; set; }

        [ProtoMember(2)]
        public List<ArgumentListAssociation> ArgumentListAssociations { get; set; }

        public ArgumentListSyntax GetArgumentListSyntax()
        {
            if (ArgumentListAssociations.Count == 1)
            {
                return ArgumentList(
                    SingletonSeparatedList(
                        ArgumentListAssociations
                            .First()
                            .Argument
                            .GetArgumentSyntax()));
            }
            var last = ArgumentListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    ArgumentListAssociations[i]
                        .Argument
                        .GetArgumentSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return ArgumentList(
                SeparatedList<ArgumentSyntax>(
                    list));
        }
    }
}
