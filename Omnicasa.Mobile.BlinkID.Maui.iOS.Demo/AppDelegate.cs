namespace Omnicasa.Mobile.BlinkID.Maui.iOS.Demo;

/// <summary>IBlinkScannerOverlayViewControllerDelegate</summary>
internal interface IBlinkScannerOverlayViewControllerDelegate
{
    /// <summary>
    /// BlinkIdOverlayViewControllerDidFinishScanning.
    /// </summary>
    /// <param name="blinkIdOverlayViewController">MBBlinkIdOverlayViewController.</param>
    /// <param name="state">MBRecognizerResultState.</param>
    void BlinkIdOverlayViewControllerDidFinishScanning(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController,
        MBRecognizerResultState state);

    /// <summary>
    /// BlinkIdOverlayViewControllerDidTapClose.
    /// </summary>
    /// <param name="blinkIdOverlayViewController">MBBlinkIdOverlayViewController.</param>
    void BlinkIdOverlayViewControllerDidTapClose(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController);
}

/// <inheritdoc/>
internal class CustomMBBlinkIdOverlayViewControllerDelegate : NSObject, IMBBlinkIdOverlayViewControllerDelegate
{
    private IBlinkScannerOverlayViewControllerDelegate controllerDelegate;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomMBBlinkIdOverlayViewControllerDelegate"/> class.
    /// </summary>
    /// <param name="controllerDelegate">IBlinkScannerOverlayViewControllerDelegate.</param>
    public CustomMBBlinkIdOverlayViewControllerDelegate(
        IBlinkScannerOverlayViewControllerDelegate controllerDelegate)
    {
        this.controllerDelegate = controllerDelegate;
    }

    /// <inheritdoc/>
    public void BlinkIdOverlayViewControllerDidFinishScanning(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state)
    {
        controllerDelegate?.BlinkIdOverlayViewControllerDidFinishScanning(
            blinkIdOverlayViewController,
            state);
    }

    /// <inheritdoc/>
    public void BlinkIdOverlayViewControllerDidTapClose(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
        controllerDelegate?.BlinkIdOverlayViewControllerDidTapClose(
            blinkIdOverlayViewController);
    }
}

/// <inheritdoc/>
[Register("AppDelegate")]
public class AppDelegate :
    UIApplicationDelegate,
    IMBBlinkIdOverlayViewControllerDelegate,
    IBlinkScannerOverlayViewControllerDelegate
{
    private UIViewController? vc;
    private MBBlinkIdMultiSideRecognizer? mBBlinkIdMultiSideRecognizer;
    private MBLicenseError? mBLicenseError;
    private UIViewController? scannerViewController;

    /// <inheritdoc/>
    public const string iOSLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";

    /// <inheritdoc/>
    public override UIWindow? Window
    {
        get;
        set;
    }

    /// <inheritdoc/>
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        vc = new UIViewController();
        vc.View!.AddSubview(new UILabel(Window!.Frame)
        {
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
        Window.MakeKeyAndVisible();

        MBMicroblinkSDK.SharedInstance().SetLicenseKey(
            iOSLic,
            (error) =>
            {
                mBLicenseError = error;
            });

        return true;
    }

    private void But_TouchUpInside(object? sender, EventArgs e)
    {
        if (mBLicenseError.HasValue || vc == null)
        {
            return;
        }

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

        if (recognizerRunneViewController == null)
        {
            return;
        }

        scannerViewController = ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunneViewController.Handle, false);
        if (scannerViewController == null)
        {
            return;
        }

        vc.PresentViewController(scannerViewController, true, null);
    }

    /// <inheritdoc/>
    public void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state)
    {
        if (state == MBRecognizerResultState.Valid)
        {
            var result = mBBlinkIdMultiSideRecognizer?.Result;
            if (result != null)
            {
                System.Diagnostics.Debug.WriteLine($"{result.LastName?.ToString() ?? string.Empty} {result.FirstName?.ToString() ?? string.Empty}");
                DismissScanController();
            }
        }
    }

    /// <inheritdoc/>
    public void BlinkIdOverlayViewControllerDidTapClose(
        MBBlinkIdOverlayViewController blinkIdOverlayViewController)
    {
        DismissScanController();
    }

    /// <inheritdoc/>
    private void DismissScanController()
    {
        if (scannerViewController != null)
        {
            scannerViewController.DismissViewController(true, null);
        }
    }
}
