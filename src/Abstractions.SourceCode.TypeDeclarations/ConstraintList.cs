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
    [Table("ConstraintLists", Schema = nameof(SourceCode))]
    public class ConstraintList
    {
        [Key]
        [ProtoMember(1)]
        public int ConstraintListId { get; set; }

        [ProtoMember(2)]
        public List<ConstraintListAssociation> ConstraintListAssociations { get; set; }

        public SeparatedSyntaxList<TypeParameterConstraintSyntax> GetConstraintList()
        {
            if (ConstraintListAssociations.Count == 1)
            {
                return SingletonSeparatedList(
                    ConstraintListAssociations
                        .First()
                        .Constraint
                        .GetTypeParameterConstraintSyntax());
            }
            var last = ConstraintListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    ConstraintListAssociations[i]
                        .Constraint
                        .GetTypeParameterConstraintSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return SeparatedList<TypeParameterConstraintSyntax>(list);
        }
    }
}
