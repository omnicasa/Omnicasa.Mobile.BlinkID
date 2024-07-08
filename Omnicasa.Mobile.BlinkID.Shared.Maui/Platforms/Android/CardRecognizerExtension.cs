using System;
using Com.Microblink.Entities.Recognizers.Blinkid.Generic;
using Omnicasa.Mobile.BlinkID.Shared.Maui;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>CardRecognizerExtension.</summary>
    public static class CardRecognizerExtension
    {
        /// <summary>
        /// Parse.
        /// </summary>
        /// <param name="recognizerResult">MBBlinkIdMultiSideRecognizerResult.</param>
        /// <returns>CardRecognizer.</returns>
        public static CardRecognizer? Parse(this BlinkIdCombinedRecognizer.Result recognizerResult)
        {
            if (recognizerResult == null)
            {
                return null;
            }

            return new CardRecognizer()
            {
                FirstName = recognizerResult.FirstName,
                LastName = recognizerResult.LastName,
                FullName = recognizerResult.FullName,
            };
        }

        /// <summary>
        /// Parse.
        /// </summary>
        /// <param name="recognizerResult">MBBlinkIdMultiSideRecognizerResult.</param>
        /// <returns>CardRecognizer.</returns>
        public static CardRecognizerExtended? ParseExtended(this BlinkIdCombinedRecognizer.Result recognizerResult)
        {
            if (recognizerResult == null)
            {
                return null;
            }

            return new CardRecognizerExtended()
            {
                FirstName = recognizerResult.FirstName,
                LastName = recognizerResult.LastName,
                FullName = recognizerResult.FullName,
            };
        }
    }
}
