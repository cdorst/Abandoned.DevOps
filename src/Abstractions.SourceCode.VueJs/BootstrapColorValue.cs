namespace Abstractions.SourceCode.VueJs
{
    public static class BootstrapColorValue
    {
        public static string GetValue(BootstrapColor color)
            => color == BootstrapColor.Primary ? nameof(BootstrapColor.Primary).ToLower()
            : color == BootstrapColor.Secondary ? nameof(BootstrapColor.Secondary).ToLower()
            : color == BootstrapColor.Success ? nameof(BootstrapColor.Success).ToLower()
            : color == BootstrapColor.Danger ? nameof(BootstrapColor.Danger).ToLower()
            : color == BootstrapColor.Warning ? nameof(BootstrapColor.Warning).ToLower()
            : color == BootstrapColor.Info ? nameof(BootstrapColor.Info).ToLower()
            : color == BootstrapColor.Light ? nameof(BootstrapColor.Light).ToLower()
            : color == BootstrapColor.Dark ? nameof(BootstrapColor.Dark).ToLower()
            : nameof(BootstrapColor.Link).ToLower();
    }
}
