using Android.App;
using Android.Content.PM;
using Android.OS;
using KChristmas.Core;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;

namespace KChristmas.Android
{
    [Activity(
        Label = "Merry Christmas, Kaisa!",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
    )]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Platform.Init(this, bundle);
        }
    }
}
