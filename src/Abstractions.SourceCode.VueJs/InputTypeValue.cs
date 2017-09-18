namespace Abstractions.SourceCode.VueJs
{
    public static class InputTypeValue
    {
        public static string GetValue(InputType type)
            => type == InputType.Button ? nameof(InputType.Button).ToLower()
            : type == InputType.Checkbox ? nameof(InputType.Checkbox).ToLower()
            : type == InputType.Color ? nameof(InputType.Color).ToLower()
            : type == InputType.Date ? nameof(InputType.Date).ToLower()
            : type == InputType.DatetimeLocal ? "datetime-local"
            : type == InputType.Email ? nameof(InputType.Email).ToLower()
            : type == InputType.File ? nameof(InputType.File).ToLower()
            : type == InputType.Hidden ? nameof(InputType.Hidden).ToLower()
            : type == InputType.Image ? nameof(InputType.Image).ToLower()
            : type == InputType.Month ? nameof(InputType.Month).ToLower()
            : type == InputType.Number ? nameof(InputType.Number).ToLower()
            : type == InputType.Password ? nameof(InputType.Password).ToLower()
            : type == InputType.Radio ? nameof(InputType.Radio).ToLower()
            : type == InputType.Range ? nameof(InputType.Range).ToLower()
            : type == InputType.Reset ? nameof(InputType.Reset).ToLower()
            : type == InputType.Search ? nameof(InputType.Search).ToLower()
            : type == InputType.Submit ? nameof(InputType.Submit).ToLower()
            : type == InputType.Tel ? nameof(InputType.Tel).ToLower()
            : type == InputType.Time ? nameof(InputType.Time).ToLower()
            : type == InputType.Url ? nameof(InputType.Url).ToLower()
            : type == InputType.Week ? nameof(InputType.Week).ToLower()
            : nameof(InputType.Text).ToLower();
    }
}
