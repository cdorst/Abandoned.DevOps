using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("FormGroups", Schema = nameof(VueJs))]
    public class FormGroup
    {
        [Key]
        [ProtoMember(1)]
        public int FormGroupId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference HelpText { get; set; }
        [ProtoMember(3)]
        public int? HelpTextId { get; set; }
        [ProtoMember(4)]
        public Input Input { get; set; }
        [ProtoMember(5)]
        public int InputId { get; set; }
        [ProtoMember(6)]
        public AsciiStringReference Label { get; set; }
        [ProtoMember(7)]
        public int? LabelId { get; set; }

        public string GetTemplate()
        {
            var sb = new StringBuilder("<div class=\"form-group\">");
            if (Label != null)
            {
                sb.Append($"<label for=\"{Input.Identifier.Value}\">{Label.Value}</label>");
            }
            var useHelpText = HelpText != null;
            sb.Append(Input.GetTemplate(useHelpText, Label?.Value));
            if (useHelpText)
            {
                sb.Append($"<small id=\"{Input.Identifier.Value}HelpText\" class=\"form-text text-muted\">{HelpText.Value}</small>");
            }
            return sb.Append("</div>").ToString();
        }
    }
}
