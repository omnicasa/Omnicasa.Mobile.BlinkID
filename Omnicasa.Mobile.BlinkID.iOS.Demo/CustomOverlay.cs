using System;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.iOS.Demo
#pragma warning restore SA1300
{
    /// <inheritdoc/>
    public class CustomMBFirstSideFinishedRecognizerRunnerViewControllerDelegate
        : MBFirstSideFinishedRecognizerRunnerViewControllerDelegate
    {
        /// <inheritdoc/>
        public override void RecognizerRunnerViewControllerDidFinishRecognitionOfFirstSide(
            MBRecognizerRunnerViewController recognizerRunnerViewController)
        {
            throw new NotImplementedException();
        }
    }

    /// <inheritdoc/>
    public class CustomMBScanningRecognizerRunnerViewControllerDelegate
        : MBScanningRecognizerRunnerViewControllerDelegate
    {
        /// <inheritdoc/>
        public override void State(
            MBRecognizerRunnerViewController recognizerRunnerViewController,
            MBRecognizerResultState state)
        {
            throw new NotImplementedException();
        }
    }

    /// <inheritdoc/>
    public class CustomOverlay : MBCustomOverlayViewController
    {
        /// <inheritdoc/>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ScanningRecognizerRunnerViewControllerDelegate =
                new CustomMBScanningRecognizerRunnerViewControllerDelegate();
            MetadataDelegates
                .FirstSideFinishedRecognizerRunnerViewControllerDelegate =
                new CustomMBFirstSideFinishedRecognizerRunnerViewControllerDelegate();
        }
    }
}
