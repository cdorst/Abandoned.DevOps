using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using System.Linq;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("ConstraintClauseLists", Schema = nameof(SourceCode))]
    public class ConstraintClauseList
    {
        [Key]
        [ProtoMember(1)]
        public int ConstraintClauseListId { get; set; }

        [ProtoMember(2)]
        public List<ConstraintClauseListAssociation> ConstraintClauseListAssociations { get; set; }

        public SyntaxList<TypeParameterConstraintClauseSyntax> GetConstraintClauses()
            => ConstraintClauseListAssociations.Count == 1
            ? SingletonList(
                ConstraintClauseListAssociations
                    .First()
                    .ConstraintClause
                    .GetTypeParameterConstraintClauseSyntax())
            : List(
                ConstraintClauseListAssociations
                    .Select(c => c.ConstraintClause.GetTypeParameterConstraintClauseSyntax()));
    }
}
