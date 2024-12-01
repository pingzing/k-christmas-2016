namespace KChristmas.Core.Extensions
{
    public static class MauiExtensions
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            return builder.Build();
        }
    }
}
