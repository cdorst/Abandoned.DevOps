using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("ConstructorLists", Schema = nameof(SourceCode))]
    public class ConstructorList
    {
        [Key]
        [ProtoMember(1)]
        public int ConstructorListId { get; set; }

        [ProtoMember(2)]
        public List<ConstructorListAssociation> ConstructorListAssociations { get; set; }

        public IEnumerable<MemberDeclarationSyntax> GetMemberDeclarationSyntax()
            => MemberDeclarationSorter.Sort(ConstructorListAssociations.Select(c => c.Constructor));
    }
}
