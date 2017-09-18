using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("AttributeListCollectionAssociations", Schema = nameof(SourceCode))]
    public class AttributeListCollectionAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int AttributeListCollectionAssociationId { get; set; }

        [ProtoMember(2)]
        public Attribute Attribute { get; set; }
        [ProtoMember(3)]
        public int AttributeId { get; set; }

        [ProtoMember(4)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(5)]
        public int AttributeListCollectionId { get; set; }
    }
}
