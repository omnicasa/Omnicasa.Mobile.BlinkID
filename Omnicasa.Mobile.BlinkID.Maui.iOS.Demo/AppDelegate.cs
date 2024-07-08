namespace Omnicasa.Mobile.BlinkID.Maui.iOS.Demo;

interface IBlinkScannerOverlayViewControllerDelegate
{
    void BlinkIdOverlayViewControllerDidFinishScanning(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController,
        MBRecognizerResultState state);

    void BlinkIdOverlayViewControllerDidTapClose(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController);
}

class CustomMBBlinkIdOverlayViewControllerDelegate : NSObject, IMBBlinkIdOverlayViewControllerDelegate
{
    private IBlinkScannerOverlayViewControllerDelegate controllerDelegate;

    public CustomMBBlinkIdOverlayViewControllerDelegate(
        IBlinkScannerOverlayViewControllerDelegate controllerDelegate)
    {
        this.controllerDelegate = controllerDelegate;
    }

    public void BlinkIdOverlayViewControllerDidFinishScanning(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state)
    {
        controllerDelegate?.BlinkIdOverlayViewControllerDidFinishScanning(
            blinkIdOverlayViewController,
            state);
    }

    public void BlinkIdOverlayViewControllerDidTapClose(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
        controllerDelegate?.BlinkIdOverlayViewControllerDidTapClose(
            blinkIdOverlayViewController);
    }
}

[Register ("AppDelegate")]
public class AppDelegate :
    UIApplicationDelegate,
    IMBBlinkIdOverlayViewControllerDelegate,
    IBlinkScannerOverlayViewControllerDelegate
{
    private UIViewController vc;
    private MBBlinkIdMultiSideRecognizer mBBlinkIdMultiSideRecognizer;
    public const string iOSLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";


    public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// create a UIViewController with a single UILabel
		vc = new UIViewController ();
		vc.View!.AddSubview (new UILabel (Window!.Frame) {
			BackgroundColor = UIColor.SystemBackground,
			TextAlignment = UITextAlignment.Center,
			Text = "Hello, iOS!",
			AutoresizingMask = UIViewAutoresizing.All,
		});

        var but = new UIButton(new CGRect(100, 100, 100, 100))
        {
            BackgroundColor = UIColor.Red,
            AutoresizingMask = UIViewAutoresizing.All,
        };
        but.SetTitle("Start scan", UIControlState.Normal);
        but.TouchUpInside += But_TouchUpInside;
        vc.View!.AddSubview(but);

        Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

        MBMicroblinkSDK.SharedInstance().SetLicenseKey(iOSLic,
            (error) =>
            {


            });

        return true;
	}

    private void But_TouchUpInside(object? sender, EventArgs e)
    {
        MBMicroblinkSDK.SharedInstance().SetLicenseKey(iOSLic, (MBLicenseError arg0) =>
        {
            System.Diagnostics.Debug.WriteLine(arg0.ToString());
        });

        mBBlinkIdMultiSideRecognizer = new MBBlinkIdMultiSideRecognizer();
        mBBlinkIdMultiSideRecognizer.ReturnFullDocumentImage = true;

        MBBlinkIdOverlaySettings mBBlinkIdOverlaySettings = new MBBlinkIdOverlaySettings();
        MBRecognizerCollection mBRecognizerCollection = new MBRecognizerCollection(new[] { mBBlinkIdMultiSideRecognizer });

        MBBlinkIdOverlayViewController mBBlinkIdOverlayViewController = new MBBlinkIdOverlayViewController(
            mBBlinkIdOverlaySettings,
            mBRecognizerCollection,
            new CustomMBBlinkIdOverlayViewControllerDelegate(this));

        var recognizerRunneViewController = MBViewControllerFactory
            .RecognizerRunnerViewControllerWithOverlayViewController(mBBlinkIdOverlayViewController);

        vc.PresentViewController(
            ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunneViewController.Handle, false),
            true,
            null);
    }

    public void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state)
    {
        System.Diagnostics.Debug.WriteLine($"DidFinishScanning with state={state}");
        if (state == MBRecognizerResultState.Valid)
        {
            var result = mBBlinkIdMultiSideRecognizer.Result;
            if (result != null)
            {
                System.Diagnostics.Debug.WriteLine(result.FirstName?.ToString() ?? "");
                System.Diagnostics.Debug.WriteLine(result.LastName?.ToString() ?? "");
            }
        }
    }

    public void BlinkIdOverlayViewControllerDidTapClose(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
    }
}

