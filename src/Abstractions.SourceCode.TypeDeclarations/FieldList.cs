using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("FieldLists", Schema = nameof(SourceCode))]
    public class FieldList
    {
        [Key]
        [ProtoMember(1)]
        public int FieldListId { get; set; }

        [ProtoMember(2)]
        public List<FieldListAssociation> FieldListAssociations { get; set; }

        public IEnumerable<MemberDeclarationSyntax> GetMemberDeclarationSyntax()
            => MemberDeclarationSorter.Sort(FieldListAssociations.Select(f => f.Field));
    }
}
