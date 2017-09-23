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
    [Table("BaseLists", Schema = nameof(SourceCode))]
    public class BaseList
    {
        [Key]
        [ProtoMember(1)]
        public int BaseListId { get; set; }

        [ProtoMember(2)]
        public List<BaseListAssociation> BaseListAssociations { get; set; }

        public BaseListSyntax GetBaseListSyntax()
        {
            if (BaseListAssociations.Count == 1)
            {
                return BaseList(
                    SingletonSeparatedList<BaseTypeSyntax>(
                        BaseListAssociations
                            .First()
                            .BaseType
                            .GetSimpleBaseTypeSyntax()));
            }
            var last = BaseListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    BaseListAssociations[i]
                        .BaseType
                        .GetSimpleBaseTypeSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return BaseList(
                SeparatedList<BaseTypeSyntax>(
                    list));
        }
    }
}
