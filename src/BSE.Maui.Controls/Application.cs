namespace BSE.Maui.Controls
{
    public partial class Application
    {
        public static bool IsApplicationOrNull(object? element) =>
            element == null || element is IApplication;
    }
}
