using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("Fieldsets", Schema = nameof(VueJs))]
    public class Fieldset
    {
        [Key]
        [ProtoMember(1)]
        public int FieldsetId { get; set; }

        [ProtoMember(2)]
        public bool Disabled { get; set; }

        [ProtoMember(3)]
        public List<FieldsetFormGroupAssociation> FormGroups { get; set; }

        public string GetTemplate()
        {
            var sb = new StringBuilder("<fieldset");
            if (Disabled) sb.Append(" disabled");
            sb.Append(">");
            foreach (var formGroup in FormGroups?.Select(f => f.FormGroup.GetTemplate()) ?? new string[] { })
            {
                sb.Append(formGroup);
            }
            sb.Append("</fieldset>");
            return sb.ToString();
        }
    }
}
