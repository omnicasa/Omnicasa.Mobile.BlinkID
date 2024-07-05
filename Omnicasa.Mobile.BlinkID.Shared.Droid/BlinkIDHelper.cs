using System;
using Android.App;
using Android.Content;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>BlinkIDHelper.</summary>
    public static class BlinkIDHelper
    {
        /// <summary>Scanned.</summary>
        public static EventHandler<RecognizingState>? Scanned { get; set; }

        /// <summary>
        /// OnActivityResult.
        /// </summary>
        /// <param name="requestCode">int.</param>
        /// <param name="resultCode">Result.</param>
        /// <param name="data">Intent.</param>
        public static void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == BlinkIDConstants.BLINK_SCAN_REQUEST_ID
                && resultCode == Result.Ok)
            {
                Scanned?.Invoke(null, RecognizingState.DidFinishedScanning);
            }
        }
    }
}
