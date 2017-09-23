using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("ParameterListAssociations", Schema = nameof(SourceCode))]
    public class ParameterListAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int ParameterListAssociationId { get; set; }

        [ProtoMember(2)]
        public Parameter Parameter { get; set; }
        [ProtoMember(3)]
        public int ParameterId { get; set; }

        [ProtoMember(4)]
        public ParameterList ParameterList { get; set; }
        [ProtoMember(5)]
        public int ParameterListId { get; set; }
    }
}
