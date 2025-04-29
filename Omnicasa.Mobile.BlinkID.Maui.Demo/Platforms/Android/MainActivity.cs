using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Omnicasa.Mobile.BlinkID.Shared.Droid;
using Omnicasa.Mobile.BlinkID.Shared.Maui;
using Unity;

namespace Omnicasa.Mobile.BlinkID.Maui.Demo;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        BlinkIDInitializer.Init(this, this);
        App.Container.RegisterType<IBlinkIDServiceExtended, BlinkIDService>();
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        BlinkIDHelper.OnActivityResult(requestCode, resultCode, data);
    }
}

