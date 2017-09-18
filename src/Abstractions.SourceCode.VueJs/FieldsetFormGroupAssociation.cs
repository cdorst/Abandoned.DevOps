using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("FieldsetFormGroupAssociations", Schema = nameof(VueJs))]
    public class FieldsetFormGroupAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int FieldsetFormGroupAssociationId { get; set; }
        [ProtoMember(2)]
        public Fieldset Fieldset { get; set; }
        [ProtoMember(3)]
        public int FieldsetId { get; set; }
        [ProtoMember(4)]
        public FormGroup FormGroup { get; set; }
        [ProtoMember(5)]
        public int FormGroupId { get; set; }
    }
}
