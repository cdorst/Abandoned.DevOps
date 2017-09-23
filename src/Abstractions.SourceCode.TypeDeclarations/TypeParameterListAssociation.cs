using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("TypeParameterListAssociations", Schema = nameof(SourceCode))]
    public class TypeParameterListAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int TypeParameterListAssociationId { get; set; }

        [ProtoMember(2)]
        public TypeParameter TypeParameter { get; set; }
        [ProtoMember(3)]
        public int TypeParameterId { get; set; }

        [ProtoMember(4)]
        public TypeParameterList TypeParameterList { get; set; }
        [ProtoMember(5)]
        public int TypeParameterListId { get; set; }
    }
}
