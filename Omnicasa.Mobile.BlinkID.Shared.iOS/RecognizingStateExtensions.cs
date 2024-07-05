using Omnicasa.Mobile.BlinkID.iOS;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Shared.iOS
#pragma warning restore SA1300
{
    /// <summary>RecognizingStateExtensions.</summary>
    public static class RecognizingStateExtensions
    {
        /// <summary>
        /// Parse.
        /// </summary>
        /// <param name="mBRecognizerResultState">MBRecognizerResultState.</param>
        public static RecognizingState Parse(this MBRecognizerResultState mBRecognizerResultState)
        {
            switch (mBRecognizerResultState)
            {
                case MBRecognizerResultState.Valid:
                    return RecognizingState.DidFinishedScanningValid;

                case MBRecognizerResultState.Empty:
                    return RecognizingState.DidFinishedScanningEmpty;

                case MBRecognizerResultState.StageValid:
                    return RecognizingState.DidFinishedScanningStageValid;

                case MBRecognizerResultState.Uncertain:
                    return RecognizingState.DidFinishedScanningStageUncertain;

                default:
                    return RecognizingState.DidFinishedScanning;
            }
        }
    }
}
