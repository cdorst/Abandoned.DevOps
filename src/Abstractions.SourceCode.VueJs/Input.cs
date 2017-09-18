using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstractions.SourceCode.VueJs
{
    [ProtoContract]
    [Table("Inputs", Schema = nameof(VueJs))]
    public class Input
    {
        [Key]
        [ProtoMember(1)]
        public int InputId { get; set; }
        [ProtoMember(2)]
        public BootstrapColor? ButtonColor { get; set; }
        [ProtoMember(3)]
        public bool? ButtonOutline { get; set; }
        [ProtoMember(4)]
        public ControlSize ControlSize { get; set; }
        [ProtoMember(5)]
        public InputType InputType { get; set; }
        [ProtoMember(6)]
        public ReadonlyType? ReadonlyType { get; set; }
        [ProtoMember(7)]
        public CheckboxList CheckboxList { get; set; }
        [ProtoMember(8)]
        public int? CheckboxListId { get; set; }
        [ProtoMember(9)]
        public AsciiStringReference Identifier { get; set; }
        [ProtoMember(10)]
        public int IdentifierId { get; set; }
        [ProtoMember(11)]
        public AsciiStringReference Placeholder { get; set; }
        [ProtoMember(12)]
        public int? PlaceholderId { get; set; }
        [ProtoMember(13)]
        public RadioList RadioList { get; set; }
        [ProtoMember(14)]
        public int? RadioListId { get; set; }
        [ProtoMember(15)]
        public SelectInput SelectInput { get; set; }
        [ProtoMember(16)]
        public int? SelectInputId { get; set; }
        [ProtoMember(17)]
        public Validation Validation { get; set; }
        [ProtoMember(18)]
        public int? ValidationId { get; set; }
        [ProtoMember(19)]
        public AsciiStringReference VModel { get; set; }
        [ProtoMember(20)]
        public int? VModelId { get; set; }

        public string GetTemplate(bool useHelpText, string label)
            => CheckboxList != null ? CheckboxList.GetTemplate(VModel.Value) 
            : RadioList != null ? RadioList.GetTemplate(VModel.Value) 
            : InputType == InputType.File ? $"<label class=\"custom-file\"><input type=\"file\" id=\"{Identifier.Value}\" name=\"{Identifier.Value}\" class=\"custom-file-input\"><span class=\"custom-file-control\"></span></label>"
            : $"<{getOpeningTag()}{getVModel()} id=\"{Identifier.Value}\" name=\"{Identifier.Value}\" type=\"{InputTypeValue.GetValue(InputType)}\" class=\"{getClass()}\"{getReadonly()}{getAriaDescribedBy(useHelpText)}{getPlaceholder()}{Validation?.GetTemplate(label)}>{getClosingTag()}{getValidationSpan()}";

        private string getAriaDescribedBy(bool useHelpText) => !useHelpText ? string.Empty
            : $" aria-describedby=\"{Identifier.Value}HelpText\"";

        private string getButtonColor() => BootstrapColorValue.GetValue(ButtonColor ?? BootstrapColor.Primary);
        private string getButtonOutline() => ButtonOutline == true ? "outline-" : string.Empty;

        private string getClass() => InputType == InputType.Button || InputType == InputType.Submit
            ? $"btn btn-{getButtonOutline()}{getButtonColor()}{getSize()}"
            : InputType == InputType.Select ? "custom-select"
            : $"form-control{getReadonlyPlaintext()}{getSize()}";

        private string getClosingTag() => InputType == InputType.Select || InputType == InputType.SelectMultiple
            ? $"{SelectInput.GetTemplate(InputType == InputType.SelectMultiple)}</select>"
            : InputType == InputType.Textarea ? "</textarea>"
            : InputType == InputType.Button || InputType == InputType.Submit ? "</button>"
            : string.Empty;

        private string getOpeningTag() => InputType == InputType.Select ? "select"
            : InputType == InputType.SelectMultiple ? "select multiple"
            : InputType == InputType.Textarea ? "textarea"
            : InputType == InputType.Button || InputType == InputType.Submit ? "button"
            : "input";

        private string getPlaceholder() => Placeholder == null ? string.Empty
            : $" {Placeholder.Value}";

        private string getReadonly() => ReadonlyType == null ? string.Empty : " readonly";
        private string getReadonlyPlaintext() => ReadonlyType == VueJs.ReadonlyType.ReadonlyPlaintext ? string.Empty : "-plaintext";

        private string getSize() => ControlSize == ControlSize.Default ? string.Empty
            : InputType == InputType.Button || InputType == InputType.Submit ? (ControlSize == ControlSize.Small ? " btn-sm" : " btn-lg")
            : ControlSize == ControlSize.Small ? " form-control-sm" : " form-control-lg";

        private string getValidationSpan() => Validation == null ? string.Empty
            : $"<span class=\"field-validation-valid\" data-valmsg-for=\"{Identifier.Value}\" data-valmsg-replace=\"true\"></span>";

        private string getVModel() => VModel == null ? string.Empty : $"v-model=\"{VModel.Value}\"";
    }
}
