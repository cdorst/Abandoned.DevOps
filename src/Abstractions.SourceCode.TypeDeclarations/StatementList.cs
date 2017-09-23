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
    [Table("StatementLists", Schema = nameof(SourceCode))]
    public class StatementList
    {
        [Key]
        [ProtoMember(1)]
        public int StatementListId { get; set; }

        [ProtoMember(2)]
        public List<StatementListAssociation> StatementListAssociations { get; set; }

        public SyntaxList<StatementSyntax> GetStatementListSyntax()
            => StatementListAssociations.Count == 1
            ? SingletonList(
                StatementListAssociations
                    .First()
                    .Statement
                    .GetStatementSyntax())
            : List(
                StatementListAssociations
                    .Select(s => s.Statement.GetStatementSyntax()));
    }
}
