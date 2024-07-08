using Foundation;
using Omnicasa.Mobile.BlinkID.Maui.iOS;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Shared.iOS
#pragma warning restore SA1300
{
    /// <inheritdoc/>
    public class CustomMBBlinkIdOverlayViewControllerDelegate
        : NSObject, IMBBlinkIdOverlayViewControllerDelegate
    {
        private readonly ICustomMBBlinkIdOverlayViewControllerDelegate? mBBlinkIdOverlayViewControllerDelegate;

        /// <summary>Scanned.</summary>
        public EventHandler<RecognizingState>? Scanned { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMBBlinkIdOverlayViewControllerDelegate"/> class.
        /// </summary>
        /// <param name="mBBlinkIdOverlayViewControllerDelegate">IMBBlinkIdOverlayViewControllerDelegate.</param>
        public CustomMBBlinkIdOverlayViewControllerDelegate(
            ICustomMBBlinkIdOverlayViewControllerDelegate? mBBlinkIdOverlayViewControllerDelegate)
        {
            this.mBBlinkIdOverlayViewControllerDelegate = mBBlinkIdOverlayViewControllerDelegate;
        }

        /// <inheritdoc/>
        public void BlinkIdOverlayViewControllerDidFinishScanning(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController,
            MBRecognizerResultState state)
        {
            mBBlinkIdOverlayViewControllerDelegate?
                .BlinkIdOverlayViewControllerDidFinishScanning(blinkIdOverlayViewController, state);
            Scanned?.Invoke(this, state.Parse());
        }

        /// <inheritdoc/>
        public void BlinkIdOverlayViewControllerDidTapClose(
            MBBlinkIdOverlayViewController blinkIdOverlayViewController)
        {
            mBBlinkIdOverlayViewControllerDelegate?
                .BlinkIdOverlayViewControllerDidTapClose(blinkIdOverlayViewController);
            Scanned?.Invoke(this, RecognizingState.DidTapClose);
        }
    }
}
