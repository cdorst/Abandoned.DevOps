using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("ConstraintListAssociations", Schema = nameof(SourceCode))]
    public class ConstraintListAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int ConstraintListAssociationId { get; set; }

        [ProtoMember(2)]
        public Constraint Constraint { get; set; }
        [ProtoMember(3)]
        public int ConstraintId { get; set; }

        [ProtoMember(4)]
        public ConstraintList ConstraintList { get; set; }
        [ProtoMember(5)]
        public int ConstraintListId { get; set; }
    }
}
