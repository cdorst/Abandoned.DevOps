using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("FormFieldsetAssociations", Schema = nameof(VueJs))]
    public class FormFieldsetAssociation
    {
        [Key]
        [ProtoMember(1)]
        public int FormFieldsetAssociationId { get; set; }
        [ProtoMember(2)]
        public Fieldset Fieldset { get; set; }
        [ProtoMember(3)]
        public int FieldsetId { get; set; }
        [ProtoMember(4)]
        public Form Form { get; set; }
        [ProtoMember(5)]
        public int FormId { get; set; }
    }
}
