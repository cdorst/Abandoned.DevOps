using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("TypeArgumentLists", Schema = nameof(SourceCode))]
    public class TypeArgumentList
    {
        [Key]
        [ProtoMember(1)]
        public int TypeArgumentListId { get; set; }

        [ProtoMember(2)]
        public List<TypeArgumentListAssociation> TypeArgumentListAssociations { get; set; }
    }
}
