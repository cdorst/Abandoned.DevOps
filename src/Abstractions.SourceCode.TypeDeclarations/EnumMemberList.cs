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
    [Table("EnumMemberLists", Schema = nameof(SourceCode))]
    public class EnumMemberList
    {
        [Key]
        [ProtoMember(1)]
        public int EnumMemberListId { get; set; }

        [ProtoMember(2)]
        public List<EnumMemberListAssociation> EnumMemberListAssociations { get; set; }

        public SeparatedSyntaxList<EnumMemberDeclarationSyntax> GetEnumMembers()
        {
            if (EnumMemberListAssociations.Count == 1)
            {
                return SingletonSeparatedList(
                    EnumMemberListAssociations
                        .First()
                        .EnumMember
                        .GetEnumMemberDeclaration());
            }
            var last = EnumMemberListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    EnumMemberListAssociations[i]
                        .EnumMember
                        .GetEnumMemberDeclaration());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return SeparatedList<EnumMemberDeclarationSyntax>(list);
        }
    }
}
