using Omnicasa.Mobile.BlinkID.Maui.iOS;
using Omnicasa.Mobile.BlinkID.Shared.Maui;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Shared.iOS
#pragma warning restore SA1300
{
    /// <summary>CardRecognizerExtension.</summary>
    public static class CardRecognizerExtension
    {
        /// <summary>
        /// Parse.
        /// </summary>
        /// <param name="recognizerResult">MBBlinkIdMultiSideRecognizerResult.</param>
        /// <returns>CardRecognizer.</returns>
        public static CardRecognizer? Parse(this MBBlinkIdMultiSideRecognizerResult recognizerResult)
        {
            if (recognizerResult == null)
            {
                return null;
            }

#pragma warning disable CA1416
            var card = new CardRecognizer()
            {
                Address = recognizerResult.Address?.Value,
                DocumentNumber = recognizerResult.DocumentNumber?.Value,
                FirstName = recognizerResult.FirstName?.Value,
                FullName = recognizerResult.FullName?.Value,
                LastName = recognizerResult.LastName?.Value,
                FathersName = recognizerResult.FathersName?.Value,
                MothersName = recognizerResult.MothersName?.Value,
                Sex = recognizerResult.Sex?.Value,
                LocalizedName = recognizerResult.LocalizedName?.Value,
                AdditionalNameInformation = recognizerResult.AdditionalNameInformation?.Value,
                AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation?.Value,
                AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation?.Value,
                PlaceOfBirth = recognizerResult.PlaceOfBirth?.Value,
                Nationality = recognizerResult.Nationality?.Value,
                Race = recognizerResult.Race?.Value,
                Religion = recognizerResult.Religion?.Value,
                Profession = recognizerResult.Profession?.Value,
                MaritalStatus = recognizerResult.MaritalStatus?.Value,
                ResidentialStatus = recognizerResult.ResidentialStatus?.Value,
                Employer = recognizerResult.Employer?.Value,
                PersonalIdNumber = recognizerResult.PersonalIdNumber?.Value,
                DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber?.Value,
                DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber?.Value,
                IssuingAuthority = recognizerResult.IssuingAuthority?.Value,
                DocumentSubtype = recognizerResult.DocumentSubtype?.Value,
                Sponsor = recognizerResult.Sponsor?.Value,
                BloodType = recognizerResult.BloodType?.Value,
            };

            card.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
            card.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
            card.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);
#pragma warning restore CA1416

            return card;
        }

        /// <summary>
        /// Parse.
        /// </summary>
        /// <param name="recognizerResult">MBBlinkIdMultiSideRecognizerResult.</param>
        /// <returns>CardRecognizer.</returns>
        public static CardRecognizerExtended? ParseExtended(this MBBlinkIdMultiSideRecognizerResult recognizerResult)
        {
            try
            {
                if (recognizerResult == null)
                {
                    return null;
                }

#pragma warning disable CA1416
                var card = new CardRecognizerExtended()
                {
                    Address = recognizerResult.Address?.Value,
                    DocumentNumber = recognizerResult.DocumentNumber?.Value,
                    FirstName = recognizerResult.FirstName?.Value,
                    FullName = recognizerResult.FullName?.Value,
                    LastName = recognizerResult.LastName?.Value,
                    FathersName = recognizerResult.FathersName?.Value,
                    MothersName = recognizerResult.MothersName?.Value,
                    Sex = recognizerResult.Sex?.Value,
                    LocalizedName = recognizerResult.LocalizedName?.Value,
                    AdditionalNameInformation = recognizerResult.AdditionalNameInformation?.Value,
                    AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation?.Value,
                    AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation?.Value,
                    PlaceOfBirth = recognizerResult.PlaceOfBirth?.Value,
                    Nationality = recognizerResult.Nationality?.Value,
                    Race = recognizerResult.Race?.Value,
                    Religion = recognizerResult.Religion?.Value,
                    Profession = recognizerResult.Profession?.Value,
                    MaritalStatus = recognizerResult.MaritalStatus?.Value,
                    ResidentialStatus = recognizerResult.ResidentialStatus?.Value,
                    Employer = recognizerResult.Employer?.Value,
                    PersonalIdNumber = recognizerResult.PersonalIdNumber?.Value,
                    DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber?.Value,
                    DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber?.Value,
                    IssuingAuthority = recognizerResult.IssuingAuthority?.Value,
                    DocumentSubtype = recognizerResult.DocumentSubtype?.Value,
                    Sponsor = recognizerResult.Sponsor?.Value,
                    BloodType = recognizerResult.BloodType?.Value,
                };

                card.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
                card.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
                card.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);

                card.FaceImage = ParseImage(recognizerResult.FaceImage);
                card.SignatureImage = ParseImage(recognizerResult.SignatureImage);
                card.FullDocumentBackImage = ParseImage(recognizerResult.FullDocumentBackImage);
                card.FullDocumentFrontImage = ParseImage(recognizerResult.FullDocumentFrontImage);
#pragma warning restore CA1416

                return card;
            }
            catch
            {
                return null;
            }
        }

        private static DateTime? ParseDateTime(MBDateResult? mBDateResult)
        {
            try
            {
                if (mBDateResult == null)
                    return null;

#pragma warning disable CA1416
                return new DateTime((int)mBDateResult.Year, (int)mBDateResult.Month, (int)mBDateResult.Day);
#pragma warning restore CA1416
            }
            catch
            {
                return null;
            }
        }

        public static ImageSource? ParseImage(MBImage? mBImage)
        {
#pragma warning disable CA1416
            if (mBImage == null || mBImage.Image == null)
                return null;

            var pngImg = mBImage.Image.AsPNG();
            if (pngImg == null)
                return null;
#pragma warning restore CA1416

            // TODO: find a more efficient way to convert bitmap without compressing to and decompressing from PNG
            return ImageSource.FromStream(() => pngImg.AsStream());
        }
    }
}
