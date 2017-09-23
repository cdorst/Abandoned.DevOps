using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("ConstructorListAssociations", Schema = nameof(SourceCode))]
    public class ConstructorListAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int ConstructorListAssociationId { get; set; }

        [ProtoMember(2)]
        public Constructor Constructor { get; set; }
        [ProtoMember(3)]
        public int ConstructorId { get; set; }

        [ProtoMember(4)]
        public ConstructorList ConstructorList { get; set; }
        [ProtoMember(5)]
        public int ConstructorListId { get; set; }
    }
}
