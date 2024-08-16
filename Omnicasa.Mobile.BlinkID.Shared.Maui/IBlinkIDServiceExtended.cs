
using System;

namespace Omnicasa.Mobile.BlinkID.Shared.Maui
{
	public interface IBlinkIDServiceExtended : IBlinkIDService
    {
        /// <summary>
        /// Scan.
        /// Limit = -1, scan forever.
        /// </summary>
        /// <returns>CardRecognizer.</returns>
        IObservable<CardRecognizerExtended?> ScanExtended(int limit = 1);

        /// <summary>
        /// ScanID.
        /// </summary>
        /// <returns></returns>
        Task<CardRecognizerExtended> ScanID();
    }
}

