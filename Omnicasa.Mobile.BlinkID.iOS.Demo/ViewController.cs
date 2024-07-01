using Foundation;
using System;
using UIKit;

namespace Omnicasa.Mobile.BlinkID.iOS.Demo
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
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