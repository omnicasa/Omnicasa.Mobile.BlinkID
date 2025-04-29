using System;
using Android.Graphics;
using Com.Microblink.Entities.Recognizers.Blinkid.Generic;
using Com.Microblink.Results.Date;
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

            var result = new CardRecognizer()
            {
                FirstName = recognizerResult.FirstName,
                LastName = recognizerResult.LastName,
                FullName = recognizerResult.FullName,
                Address = recognizerResult.Address,
                DateOfExpiryPermanent = recognizerResult.IsDateOfExpiryPermanent,
                DocumentNumber = recognizerResult.DocumentNumber,
                FathersName = recognizerResult.FathersName,
                MothersName = recognizerResult.MothersName,
                Sex = recognizerResult.Sex,
                LocalizedName = recognizerResult.LocalizedName,
                AdditionalNameInformation = recognizerResult.AdditionalNameInformation,
                AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation,
                AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation,
                PlaceOfBirth = recognizerResult.PlaceOfBirth,
                Nationality = recognizerResult.Nationality,
                Race = recognizerResult.Race,
                Religion = recognizerResult.Religion,
                Profession = recognizerResult.Profession,
                MaritalStatus = recognizerResult.MaritalStatus,
                Employer = recognizerResult.Employer,
                PersonalIdNumber = recognizerResult.PersonalIdNumber,
                DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber,
                DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber,
                IssuingAuthority = recognizerResult.IssuingAuthority,
            };

            result.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
            result.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
            result.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);

            return result;
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

            var result = new CardRecognizerExtended()
            {
                FirstName = recognizerResult.FirstName,
                LastName = recognizerResult.LastName,
                FullName = recognizerResult.FullName,
                Address = recognizerResult.Address,
                DateOfExpiryPermanent = recognizerResult.IsDateOfExpiryPermanent,
                DocumentNumber = recognizerResult.DocumentNumber,
                FathersName = recognizerResult.FathersName,
                MothersName = recognizerResult.MothersName,
                Sex = recognizerResult.Sex,
                LocalizedName = recognizerResult.LocalizedName,
                AdditionalNameInformation = recognizerResult.AdditionalNameInformation,
                AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation,
                AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation,
                PlaceOfBirth = recognizerResult.PlaceOfBirth,
                Nationality = recognizerResult.Nationality,
                Race = recognizerResult.Race,
                Religion = recognizerResult.Religion,
                Profession = recognizerResult.Profession,
                MaritalStatus = recognizerResult.MaritalStatus,
                Employer = recognizerResult.Employer,
                PersonalIdNumber = recognizerResult.PersonalIdNumber,
                DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber,
                DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber,
                IssuingAuthority = recognizerResult.IssuingAuthority,
            };

            result.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
            result.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
            result.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);

            result.FaceImage = ParseImage(recognizerResult.FaceImage);
            result.SignatureImage = ParseImage(recognizerResult.SignatureImage);
            result.FullDocumentBackImage = ParseImage(recognizerResult.FullDocumentBackImage);
            result.FullDocumentFrontImage = ParseImage(recognizerResult.FullDocumentFrontImage);
            return result;
        }
        
        private static DateTime? ParseDateTime(DateResult? dateResult)
        {
            try
            {
                if (dateResult == null || dateResult.Date == null)
                    return null;

#pragma warning disable CA1416
                return new DateTime((int)dateResult.Date.Year, (int)dateResult.Date.Month, (int)dateResult.Date.Day);
#pragma warning restore CA1416
            }
            catch
            {
                return null;
            }
        }

        public static ImageSource? ParseImage(Com.Microblink.Image.Image? mBImage)
        {
            // TODO: find a more efficient way to convert bitmap without compressing to and decompressing from JPEG
            try
            {
                var bitmap = mBImage.ConvertToBitmap();
                byte[] bitmapData;
                using (var stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                    bitmapData = stream.ToArray();
                }

                return ImageSource.FromStream(() => new MemoryStream(bitmapData));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
