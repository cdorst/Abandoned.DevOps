using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("CheckboxLists", Schema = nameof(VueJs))]
    public class CheckboxList
    {
        [Key]
        [ProtoMember(1)]
        public int CheckboxListId { get; set; }

        [ProtoMember(2)]
        public bool Stacked { get; set; }

        [ProtoMember(3)]
        public Input Input { get; set; }
        [ProtoMember(4)]
        public int InputId { get; set; }

        [ProtoMember(5)]
        public List<CheckboxListItem> Items { get; set; }

        public string GetTemplate(string vmodel)
        {
            var controls = Items?.Select(i => i.GetTemplate(vmodel)) ?? new string[] { };
            if (Stacked)
            {
                var sb = new StringBuilder("<div class=\"custom-controls-stacked\">");
                foreach (var control in controls)
                {
                    sb.Append(control);
                }
                sb.Append("</div>");
                return sb.ToString();
            }
            return string.Join("", controls);
        }
    }
}
