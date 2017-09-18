using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("FieldsetFormGroupAssociations", Schema = nameof(VueJs))]
    public class SelectInput
    {
        [Key]
        [ProtoMember(1)]
        public int SelectInputId { get; set; }
        [ProtoMember(2)]
        public AsciiStringReference VFor { get; set; }
        [ProtoMember(3)]
        public int VForId { get; set; }
        [ProtoMember(4)]
        public AsciiStringReference ValueProperty { get; set; }
        [ProtoMember(5)]
        public int ValuePropertyId { get; set; }
        [ProtoMember(6)]
        public AsciiStringReference TextProperty { get; set; }
        [ProtoMember(7)]
        public int TextPropertyId { get; set; }

        public string GetTemplate(bool selectMultiple)
            => $"<option disabled value=\"\">Please select one{orMore(selectMultiple)}</option><option v-for=\"option in {VFor.Value}\" v-bind:value=\"option.{ValueProperty.Value}\">{{{{ option.{TextProperty.Value} }}}}</option>";

        private string orMore(bool selectMultiple) => selectMultiple ? " or more" : string.Empty;
    }
}
