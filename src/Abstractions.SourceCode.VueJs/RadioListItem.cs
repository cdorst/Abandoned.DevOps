using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("RadioListItems", Schema = nameof(VueJs))]
    public class RadioListItem
    {
        [Key]
        [ProtoMember(1)]
        public int RadioListItemId { get; set; }
        [ProtoMember(2)]
        public bool Disabled { get; set; }

        [ProtoMember(3)]
        public RadioList RadioList { get; set; }
        [ProtoMember(4)]
        public int RadioListId { get; set; }
        [ProtoMember(5)]
        public AsciiStringReference Identifier { get; set; }
        [ProtoMember(6)]
        public int IdentifierId { get; set; }
        [ProtoMember(7)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(8)]
        public int NameId { get; set; }
        [ProtoMember(9)]
        public AsciiStringReference Description { get; set; }
        [ProtoMember(10)]
        public int DescriptionId { get; set; }
        [ProtoMember(11)]
        public AsciiStringReference Value { get; set; }
        [ProtoMember(12)]
        public int? ValueId { get; set; }

        public string GetTemplate(string vmodel)
        {
            var sb = new StringBuilder($"<label class\"custom-control custom-radio\"><input id=\"{Identifier.Value}\" name=\"{Name.Value}\" type=\"radio\" class=\"custom-control-input\"{getVModel(vmodel)}{getValue()}");
            if (Disabled) sb.Append(" disabled");
            sb.Append($"><span class=\"custom-control-indicator\"></span><span class=\"custom-control-description\">{Description.Value}</span></label>");
            return sb.ToString();
        }

        private string getValue() => Value == null ? string.Empty : $" value=\"{Value.Value}\"";
        private string getVModel(string vmodel) => string.IsNullOrEmpty(vmodel) ? string.Empty : $" v-model=\"{vmodel}\"";
    }
}
