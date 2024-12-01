using Android.App;
using Android.Runtime;

namespace KChristmas.Android
{
#if DEBUG
    [Application(UsesCleartextTraffic = true)]
#else
    [Application]
#endif
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership) { }

        protected override MauiApp CreateMauiApp()
        {
            return Core.Extensions.MauiExtensions.CreateMauiApp();
        }
    }
}
