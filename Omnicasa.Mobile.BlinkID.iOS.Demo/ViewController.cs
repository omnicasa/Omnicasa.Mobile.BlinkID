using System;
using CoreGraphics;
using UIKit;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.iOS.Demo
#pragma warning restore SA1300
{
    /// <inheritdoc/>
    internal interface IMBBlinkIdOverlayViewControllerDelegate
    {
        /// <inheritdoc/>
        void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state);

        /// <inheritdoc/>
        void BlinkIdOverlayViewControllerDidTapClose(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController);
    }

    /// <inheritdoc/>
    internal class CustomMBBlinkIdOverlayViewControllerDelegate : MBBlinkIdOverlayViewControllerDelegate
    {
        private IMBBlinkIdOverlayViewControllerDelegate controllerDelegate;

        /// <inheritdoc/>
        public CustomMBBlinkIdOverlayViewControllerDelegate(
            IMBBlinkIdOverlayViewControllerDelegate controllerDelegate)
        {
            this.controllerDelegate = controllerDelegate;
        }

        /// <inheritdoc/>
        public override void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state)
        {
            controllerDelegate.BlinkIdOverlayViewControllerDidFinishScanning(
                blinkIdOverlayViewController,
                state);
        }

        /// <inheritdoc/>
        public override void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController)
        {
            controllerDelegate.BlinkIdOverlayViewControllerDidTapClose(blinkIdOverlayViewController);
        }
    }

    /// <inheritdoc/>
    public partial class ViewController : UIViewController, IMBBlinkIdOverlayViewControllerDelegate
    {
        private MBBlinkIdMultiSideRecognizer? mBBlinkIdMultiSideRecognizer;
        private MBLicenseError? mBLicenseError;
        private UIViewController? scannerViewController;

        /// <inheritdoc/>
        public const string iOSLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";

        /// <inheritdoc/>
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        /// <inheritdoc/>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var but = new UIButton(new CGRect(100, 100, 100, 100))
            {
                BackgroundColor = UIColor.Red,
                AutoresizingMask = UIViewAutoresizing.All,
            };
            but.SetTitle("Start scan", UIControlState.Normal);
            but.TouchUpInside += But_TouchUpInside;
            View?.AddSubview(but);

            MBMicroblinkSDK.SharedInstance().SetLicenseKey(iOSLic, (MBLicenseError arg0) =>
            {
                mBLicenseError = arg0;
            });
        }

        private void But_TouchUpInside(object sender, EventArgs e)
        {
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

            PresentViewController(scannerViewController, true, null);
        }

        /// <inheritdoc/>
        public void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state)
        {
            System.Diagnostics.Debug.WriteLine($"DidFinishScanning with state={state}");
            if (state == MBRecognizerResultState.Valid)
            {
                var result = mBBlinkIdMultiSideRecognizer?.Result;
                if (result != null)
                {
                    DismissScanController();
                    System.Diagnostics.Debug.WriteLine(result.FirstName?.ToString() ?? string.Empty);
                    System.Diagnostics.Debug.WriteLine(result.LastName?.ToString() ?? string.Empty);
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
}
