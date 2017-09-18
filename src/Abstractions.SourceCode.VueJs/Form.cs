using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("Forms", Schema = nameof(VueJs))]
    public class Form
    {
        [Key]
        [ProtoMember(1)]
        public int FormId { get; set; }

        // TODO: foreign-key to view-model object

        [ProtoMember(2)]
        public List<FormFieldsetAssociation> Fieldsets { get; set; }
        public string GetTemplate()
        {
            var sb = new StringBuilder("<form>");
            var fieldsets = Fieldsets?.Select(f => f.Fieldset.GetTemplate()) ?? new string[] { };
            foreach (var fieldset in fieldsets) sb.Append(fieldset);
            sb.Append("</form>");
            return sb.ToString();
        }

        public string GetScript()
        {
            var properties = new string[] { }; // TODO: each property in view-model
            foreach (var property in properties)
            {

            }
            return null;
        }
    }
}
