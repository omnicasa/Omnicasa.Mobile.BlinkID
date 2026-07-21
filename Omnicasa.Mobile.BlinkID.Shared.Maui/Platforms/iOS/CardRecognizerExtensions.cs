using Omnicasa.Mobile.BlinkID.Maui.iOS;
using Omnicasa.Mobile.BlinkID.Shared.Maui;
using UIKit;

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
        /// <param name="result">OmnBlinkIDResult.</param>
        /// <returns>CardRecognizer.</returns>
        public static CardRecognizer? Parse(this OmnBlinkIDResult? result)
        {
            if (result == null)
            {
                return null;
            }

            try
            {
                var card = new CardRecognizer
                {
                    Address = result.Address,
                    DocumentNumber = result.DocumentNumber,
                    FirstName = result.FirstName,
                    FullName = result.FullName,
                    LastName = result.LastName,
                    FathersName = result.FathersName,
                    MothersName = result.MothersName,
                    Sex = result.Sex,
                    LocalizedName = result.LocalizedName,
                    AdditionalNameInformation = result.AdditionalNameInformation,
                    AdditionalAddressInformation = result.AdditionalAddressInformation,
                    AdditionalOptionalAddressInformation = result.AdditionalOptionalAddressInformation,
                    PlaceOfBirth = result.PlaceOfBirth,
                    Nationality = result.Nationality,
                    Race = result.Race,
                    Religion = result.Religion,
                    Profession = result.Profession,
                    MaritalStatus = result.MaritalStatus,
                    ResidentialStatus = result.ResidentialStatus,
                    Employer = result.Employer,
                    PersonalIdNumber = result.PersonalIdNumber,
                    DocumentAdditionalNumber = result.DocumentAdditionalNumber,
                    DocumentOptionalAdditionalNumber = result.DocumentOptionalAdditionalNumber,
                    IssuingAuthority = result.IssuingAuthority,
                    DocumentSubtype = result.DocumentSubtype,
                    Sponsor = result.Sponsor,
                    BloodType = result.BloodType,
                };

                card.DateOfBirth = ParseDateTime(result.DateOfBirth);
                card.DateOfExpiry = ParseDateTime(result.DateOfExpiry);
                card.DateOfIssue = ParseDateTime(result.DateOfIssue);

                return card;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ParseExtended.
        /// </summary>
        /// <param name="result">OmnBlinkIDResult.</param>
        /// <returns>CardRecognizerExtended.</returns>
        public static CardRecognizerExtended? ParseExtended(this OmnBlinkIDResult? result)
        {
            if (result == null)
            {
                return null;
            }

            try
            {
                var card = new CardRecognizerExtended
                {
                    Address = result.Address,
                    DocumentNumber = result.DocumentNumber,
                    FirstName = result.FirstName,
                    FullName = result.FullName,
                    LastName = result.LastName,
                    FathersName = result.FathersName,
                    MothersName = result.MothersName,
                    Sex = result.Sex,
                    LocalizedName = result.LocalizedName,
                    AdditionalNameInformation = result.AdditionalNameInformation,
                    AdditionalAddressInformation = result.AdditionalAddressInformation,
                    AdditionalOptionalAddressInformation = result.AdditionalOptionalAddressInformation,
                    PlaceOfBirth = result.PlaceOfBirth,
                    Nationality = result.Nationality,
                    Race = result.Race,
                    Religion = result.Religion,
                    Profession = result.Profession,
                    MaritalStatus = result.MaritalStatus,
                    ResidentialStatus = result.ResidentialStatus,
                    Employer = result.Employer,
                    PersonalIdNumber = result.PersonalIdNumber,
                    DocumentAdditionalNumber = result.DocumentAdditionalNumber,
                    DocumentOptionalAdditionalNumber = result.DocumentOptionalAdditionalNumber,
                    IssuingAuthority = result.IssuingAuthority,
                    DocumentSubtype = result.DocumentSubtype,
                    Sponsor = result.Sponsor,
                    BloodType = result.BloodType,
                };

                card.DateOfBirth = ParseDateTime(result.DateOfBirth);
                card.DateOfExpiry = ParseDateTime(result.DateOfExpiry);
                card.DateOfIssue = ParseDateTime(result.DateOfIssue);

                card.FaceImage = ParseImage(result.FaceImage);
                card.SignatureImage = ParseImage(result.SignatureImage);
                card.FullDocumentBackImage = ParseImage(result.BackImage);
                card.FullDocumentFrontImage = ParseImage(result.FrontImage);

                return card;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ParseImage.
        /// </summary>
        /// <param name="image">UIImage.</param>
        /// <returns>ImageSource.</returns>
        public static ImageSource? ParseImage(UIImage? image)
        {
            var png = image?.AsPNG();
            if (png == null)
                return null;

            // TODO: find a more efficient way to convert without compressing to and decompressing from PNG
            return ImageSource.FromStream(() => png.AsStream());
        }

        private static DateTime? ParseDateTime(OmnBlinkIDDate? date)
        {
            try
            {
                // The shim reports 0 for components the SDK could not extract.
                if (date == null || date.Year == 0 || date.Month == 0 || date.Day == 0)
                    return null;

                return new DateTime((int)date.Year, (int)date.Month, (int)date.Day);
            }
            catch
            {
                return null;
            }
        }
    }
}
