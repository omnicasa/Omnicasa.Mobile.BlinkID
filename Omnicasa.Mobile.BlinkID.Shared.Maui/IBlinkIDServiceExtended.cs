using System;

namespace Omnicasa.Mobile.BlinkID.Shared.Maui
{
    /// <summary>
    /// IBlinkIDServiceExtended.
    /// </summary>
    public interface IBlinkIDServiceExtended : IBlinkIDService
    {
        /// <summary>
        /// Scan.
        /// Limit = -1, scan forever.
        /// </summary>
        /// <returns>CardRecognizer.</returns>
        IObservable<CardRecognizerExtended?> ScanExtended(int limit = 1, bool presentAsModal = true);

        /// <summary>
        /// ScanID.
        /// </summary>
        /// <returns>CardRecognizerExtended.</returns>
        Task<CardRecognizerExtended> ScanID();
    }
}
