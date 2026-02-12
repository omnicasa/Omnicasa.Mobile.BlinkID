using Android.Graphics;
using AndroidX.Activity.Result;
using Com.Microblink.Blinkid.Core.Result;
using Com.Microblink.Blinkid.Core.Result.Image;
using Com.Microblink.Blinkid.UX.Contract;
using Omnicasa.Mobile.BlinkID.Shared.Maui;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>CardRecognizerExtension.</summary>
    public static class CardRecognizerExtension
    {
        public static CardRecognizerExtended? Parse(this Object? obj)
        {
            try
            {
                if (obj is not ActivityResult activityResult)
                    return null;

                var contract = new MbBlinkIdScan();
                var scanResult = (BlinkIdScanActivityResult)contract.ParseResult(activityResult.ResultCode, activityResult.Data);

                if (scanResult.Status == BlinkIdScanActivityResultStatus.DocumentScanned
                    && scanResult.Result != null)
                {
                    var recognizerResult = scanResult.Result;
                    var result = new CardRecognizer()
                    {
                        FirstName = recognizerResult.FirstName?.ToString(),
                        LastName = recognizerResult.LastName?.ToString(),
                        FullName = recognizerResult.FullName?.ToString(),
                        Address = recognizerResult.Address?.ToString(),
                        DocumentNumber = recognizerResult.DocumentNumber?.ToString(),
                        FathersName = recognizerResult.FathersName?.ToString(),
                        MothersName = recognizerResult.MothersName?.ToString(),
                        Sex = recognizerResult.Sex?.ToString(),
                        LocalizedName = recognizerResult.LocalizedName?.ToString(),
                        AdditionalNameInformation = recognizerResult.AdditionalNameInformation?.ToString(),
                        AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation?.ToString(),
                        AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation?.ToString(),
                        PlaceOfBirth = recognizerResult.PlaceOfBirth?.ToString(),
                        Nationality = recognizerResult.Nationality?.ToString(),
                        Race = recognizerResult.Race?.ToString(),
                        Religion = recognizerResult.Religion?.ToString(),
                        Profession = recognizerResult.Profession?.ToString(),
                        MaritalStatus = recognizerResult.MaritalStatus?.ToString(),
                        Employer = recognizerResult.Employer?.ToString(),
                        PersonalIdNumber = recognizerResult.PersonalIdNumber?.ToString(),
                        DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber?.ToString(),
                        DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber?.ToString(),
                        IssuingAuthority = recognizerResult.IssuingAuthority?.ToString(),
                    };

                    result.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
                    result.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
                    result.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }    
        }
        
        public static CardRecognizerExtended? ParseExtended(this Object? obj)
        {
            try
            {
                if (obj is not ActivityResult activityResult)
                    return null;

                var contract = new MbBlinkIdScan();
                var scanResult = (BlinkIdScanActivityResult)contract.ParseResult(activityResult.ResultCode, activityResult.Data);

                if (scanResult.Status == BlinkIdScanActivityResultStatus.DocumentScanned
                    && scanResult.Result != null)
                {
                    var recognizerResult = scanResult.Result;
                    var result = new CardRecognizerExtended()
                    {
                        FirstName = recognizerResult.FirstName?.ToString(),
                        LastName = recognizerResult.LastName?.ToString(),
                        FullName = recognizerResult.FullName?.ToString(),
                        Address = recognizerResult.Address?.ToString(),
                        DocumentNumber = recognizerResult.DocumentNumber?.ToString(),
                        FathersName = recognizerResult.FathersName?.ToString(),
                        MothersName = recognizerResult.MothersName?.ToString(),
                        Sex = recognizerResult.Sex?.ToString(),
                        LocalizedName = recognizerResult.LocalizedName?.ToString(),
                        AdditionalNameInformation = recognizerResult.AdditionalNameInformation?.ToString(),
                        AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation?.ToString(),
                        AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation?.ToString(),
                        PlaceOfBirth = recognizerResult.PlaceOfBirth?.ToString(),
                        Nationality = recognizerResult.Nationality?.ToString(),
                        Race = recognizerResult.Race?.ToString(),
                        Religion = recognizerResult.Religion?.ToString(),
                        Profession = recognizerResult.Profession?.ToString(),
                        MaritalStatus = recognizerResult.MaritalStatus?.ToString(),
                        Employer = recognizerResult.Employer?.ToString(),
                        PersonalIdNumber = recognizerResult.PersonalIdNumber?.ToString(),
                        DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber?.ToString(),
                        DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber?.ToString(),
                        IssuingAuthority = recognizerResult.IssuingAuthority?.ToString(),
                    };

                    result.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
                    result.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
                    result.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);
                    
                    result.FaceImage = ParseImage(recognizerResult.FaceImage());
                    result.SignatureImage = ParseImage(recognizerResult.SignatureImage());
                    result.FullDocumentBackImage = ParseImage(recognizerResult.DocumentImage(ScanningSide.Second));
                    result.FullDocumentFrontImage = ParseImage(recognizerResult.DocumentImage(ScanningSide.First));
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }    
        }
        
        private static DateTime? ParseDateTime(DateResult? dateResult)
        {
            try
            {
                if (dateResult == null)
                    return null;

#pragma warning disable CA1416
                return new DateTime((int)dateResult.Year, (int)dateResult.Month, (int)dateResult.Day);
#pragma warning restore CA1416
            }
            catch
            {
                return null;
            }
        }

        public static ImageSource? ParseImage(DetailedCroppedImageResult? mBImage)
        {
            // TODO: find a more efficient way to convert bitmap without compressing to and decompressing from JPEG
            try
            {
                var bitmap = mBImage.Bitmap;
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
        
        public static ImageSource? ParseImage(CroppedImageResult? mBImage)
        {
            // TODO: find a more efficient way to convert bitmap without compressing to and decompressing from JPEG
            try
            {
                var bitmap = mBImage.Bitmap;
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
