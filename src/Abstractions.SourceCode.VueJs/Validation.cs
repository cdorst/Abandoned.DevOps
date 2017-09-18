using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("Validations", Schema = nameof(VueJs))]
    public class Validation
    {
        [Key]
        [ProtoMember(1)]
        public int ValidationId { get; set; }

        [ProtoMember(2)]
        public bool Required { get; set; }
        [ProtoMember(3)]
        public int? MinLength { get; set; }
        [ProtoMember(4)]
        public int? MaxLength { get; set; }
        [ProtoMember(5)]
        public decimal? MinValue { get; set; }
        [ProtoMember(6)]
        public decimal? MaxValue { get; set; }
        [ProtoMember(7)]
        public bool Number { get; set; }
        [ProtoMember(8)]
        public AsciiStringReference RegexErrorMessage { get; set; }
        [ProtoMember(9)]
        public int? RegexErrorMessageId { get; set; }
        [ProtoMember(10)]
        public AsciiStringReference RegexPattern { get; set; }
        [ProtoMember(11)]
        public int? RegexPatternId { get; set; }

        public string GetTemplate(string label)
        {
            var sb = new StringBuilder(" data-val=\"true\"");
            if (MinLength != null && MaxLength != null) sb.Append($" data-val-length=\"{label} must be between {MinLength} and {MaxLength} characters\"");
            else if (MinLength != null) sb.Append($" data-val-length=\"{label} must be at least {MinLength} characters\"");
            else if (MaxLength != null) sb.Append($" data-val-length=\"{label} cannot exceed {MaxLength} characters\"");
            if (MaxLength != null) sb.Append($" data-val-length-max=\"{MaxLength}\"");
            if (MinLength != null) sb.Append($" data-val-length-min=\"{MinLength}\"");
            if (Number) sb.Append($" data-val-number=\"{label} must be a number\"");
            var range = MinValue != null && MaxValue != null;
            if (range) sb.Append($" data-val-range=\"{label} must be between {MinValue} and {MaxValue}\" data-val-range-max=\"{MaxValue}\" data-val-range-min=\"{MinValue}\"");
            var regex = RegexErrorMessage != null && RegexPattern != null;
            if (regex) sb.Append($" data-val-regex=\"{RegexErrorMessage.Value}\" data-val-regex-pattern=\"{RegexPattern.Value}\"");
            if (Required) sb.Append($" data-val-required=\"{label} is required\"");
            return sb.ToString();
        }
    }
}
