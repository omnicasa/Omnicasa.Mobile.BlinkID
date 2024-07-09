using Foundation;
using Omnicasa.Mobile.BlinkID.Shared.iOS;
using Omnicasa.Mobile.BlinkID.Shared.Maui;
using UIKit;
using Unity;

namespace Omnicasa.Mobile.BlinkID.Maui.Demo;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        App.Container.RegisterType<IBlinkIDServiceExtended, BlinkIDService>();
        return base.FinishedLaunching(application, launchOptions);
    }
}

