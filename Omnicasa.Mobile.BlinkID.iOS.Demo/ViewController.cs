using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace Omnicasa.Mobile.BlinkID.iOS.Demo
{
    interface IMBBlinkIdOverlayViewControllerDelegate
    {
        void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state);

        void BlinkIdOverlayViewControllerDidTapClose(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController);
    }

    class CustomMBBlinkIdOverlayViewControllerDelegate : MBBlinkIdOverlayViewControllerDelegate
    {
        private IMBBlinkIdOverlayViewControllerDelegate controllerDelegate;

        public CustomMBBlinkIdOverlayViewControllerDelegate(
            IMBBlinkIdOverlayViewControllerDelegate controllerDelegate)
        {
            this.controllerDelegate = controllerDelegate;
        }

        public override void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state)
        {
            controllerDelegate.BlinkIdOverlayViewControllerDidFinishScanning(
                blinkIdOverlayViewController,
                state);
        }

        public override void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController)
        {
            controllerDelegate.BlinkIdOverlayViewControllerDidTapClose(blinkIdOverlayViewController);
        }
    }

    public partial class ViewController : UIViewController, IMBBlinkIdOverlayViewControllerDelegate
    {
        private MBBlinkIdMultiSideRecognizer mBBlinkIdMultiSideRecognizer;
        public const string iOSLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            var but = new UIButton(new CGRect(100, 100, 100, 100))
            {
                BackgroundColor = UIColor.Red,
                AutoresizingMask = UIViewAutoresizing.All,
            };
            but.SetTitle("Start scan", UIControlState.Normal);
            but.TouchUpInside += But_TouchUpInside;
            this.View.AddSubview(but);

            MBMicroblinkSDK.SharedInstance().SetLicenseKey(iOSLic, (MBLicenseError arg0) =>
            {
                System.Diagnostics.Debug.WriteLine(arg0.ToString());
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
                new CustomMBBlinkIdOverlayViewControllerDelegate(this)
                );

            var recognizerRunneViewController = MBViewControllerFactory
                .RecognizerRunnerViewControllerWithOverlayViewController(mBBlinkIdOverlayViewController);

            this.PresentViewController(
                ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunneViewController.Handle, false),
                true,
                null);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
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
}

/*
import UIKit
import BlinkID

class ViewController: UIViewController {

    var blinkIdRecognizer: MBBlinkIdMultiSideRecognizer?

    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Valid until: 2024-10-10
        MBMicroblinkSDK.shared().setLicenseResource("blinkid-license", withExtension: "txt", inSubdirectory: "", for: Bundle.main) { (_) in
        }
    }

    @IBAction func didTapScan(_ sender: AnyObject) {

self.blinkIdRecognizer = MBBlinkIdMultiSideRecognizer()
        self.blinkIdRecognizer?.returnFullDocumentImage = true

        let settings: MBBlinkIdOverlaySettings = MBBlinkIdOverlaySettings()

        let recognizerList = [self.blinkIdRecognizer!]
        let recognizerCollection: MBRecognizerCollection = MBRecognizerCollection(recognizers: recognizerList)

        let blinkIdOverlayViewController: MBBlinkIdOverlayViewController =
            MBBlinkIdOverlayViewController(settings: settings, recognizerCollection: recognizerCollection, delegate: self)

        guard let recognizerRunneViewController: UIViewController =
            MBViewControllerFactory.recognizerRunnerViewController(withOverlayViewController: blinkIdOverlayViewController) else
{
    return
        }
recognizerRunneViewController.modalPresentationStyle = .fullScreen

        self.present(recognizerRunneViewController, animated: true, completion: nil)
    }

    @IBAction func didTapCustomUI(_ sender: Any) {

    self.blinkIdRecognizer = MBBlinkIdMultiSideRecognizer()

        let recognizerList = [self.blinkIdRecognizer!]
        let recognizerCollection: MBRecognizerCollection = MBRecognizerCollection(recognizers: recognizerList)

        let customOverlayViewController: CustomOverlay = CustomOverlay.initFromStoryboard()

        customOverlayViewController.reconfigureRecognizers(recognizerCollection)

        guard let recognizerRunneViewController: UIViewController =
            MBViewControllerFactory.recognizerRunnerViewController(withOverlayViewController: customOverlayViewController) else
    {
        return
        }

    recognizerRunneViewController.modalPresentationStyle = .fullScreen

        self.present(recognizerRunneViewController, animated: true, completion: nil)
    }
}

extension ViewController: MBBlinkIdOverlayViewControllerDelegate {

    func blinkIdOverlayViewControllerDidFinishScanning(_ blinkIdOverlayViewController: MBBlinkIdOverlayViewController, state: MBRecognizerResultState) {
    blinkIdOverlayViewController.recognizerRunnerViewController?.pauseScanning()

        var message: String = ""
        var title: String = ""
        if self.blinkIdRecognizer?.result.resultState == MBRecognizerResultState.valid {
        title = "BlinkID"

            let fullDocumentImage: UIImage! = self.blinkIdRecognizer?.result.fullDocumentFrontImage?.image
            print("Got BlinkID image with width: \(fullDocumentImage.size.width), height: \(fullDocumentImage.size.height)")

            // Save the string representation of the code
            message = self.blinkIdRecognizer!.result.description

            DispatchQueue.main.async {
            // present the alert view with scanned results

            let alertController: UIAlertController = UIAlertController.init(title: title, message: message, preferredStyle: UIAlertController.Style.alert)

                let okAction: UIAlertAction = UIAlertAction.init(title: "OK", style: UIAlertAction.Style.default,
                                                                 handler: {
                (_)->Void in
                                                                    self.dismiss(animated: true, completion: nil)
                })
                alertController.addAction(okAction)
                blinkIdOverlayViewController.present(alertController, animated: true, completion: nil)
            }
    }
}

func blinkIdOverlayViewControllerDidTapClose(_ blinkIdOverlayViewController: MBBlinkIdOverlayViewController) {
    self.dismiss(animated: true, completion: nil)
    }
}


 */