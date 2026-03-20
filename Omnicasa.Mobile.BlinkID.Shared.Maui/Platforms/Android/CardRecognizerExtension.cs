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
        public static CardRecognizer? Parse(this Object? obj)
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
                        FirstName = recognizerResult.FirstName?.ParseStringResult(),
                        LastName = recognizerResult.LastName?.ParseStringResult(),
                        FullName = recognizerResult.FullName?.ParseStringResult(),
                        Address = recognizerResult.Address?.ParseStringResult(),
                        DocumentNumber = recognizerResult.DocumentNumber?.ParseStringResult(),
                        FathersName = recognizerResult.FathersName?.ParseStringResult(),
                        MothersName = recognizerResult.MothersName?.ParseStringResult(),
                        Sex = recognizerResult.Sex?.ParseStringResult(),
                        LocalizedName = recognizerResult.LocalizedName?.ParseStringResult(),
                        AdditionalNameInformation = recognizerResult.AdditionalNameInformation?.ParseStringResult(),
                        AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation?.ParseStringResult(),
                        AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation?.ParseStringResult(),
                        PlaceOfBirth = recognizerResult.PlaceOfBirth?.ParseStringResult(),
                        Nationality = recognizerResult.Nationality?.ParseStringResult(),
                        Race = recognizerResult.Race?.ParseStringResult(),
                        Religion = recognizerResult.Religion?.ParseStringResult(),
                        Profession = recognizerResult.Profession?.ParseStringResult(),
                        MaritalStatus = recognizerResult.MaritalStatus?.ParseStringResult(),
                        Employer = recognizerResult.Employer?.ParseStringResult(),
                        PersonalIdNumber = recognizerResult.PersonalIdNumber?.ParseStringResult(),
                        DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber?.ParseStringResult(),
                        DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber?.ParseStringResult(),
                        IssuingAuthority = recognizerResult.IssuingAuthority?.ParseStringResult(),
                    };

                    result.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
                    result.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
                    result.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);

                    return result;
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
                        FirstName = recognizerResult.FirstName?.ParseStringResult(),
                        LastName = recognizerResult.LastName?.ParseStringResult(),
                        FullName = recognizerResult.FullName?.ParseStringResult(),
                        Address = recognizerResult.Address?.ParseStringResult(),
                        DocumentNumber = recognizerResult.DocumentNumber?.ParseStringResult(),
                        FathersName = recognizerResult.FathersName?.ParseStringResult(),
                        MothersName = recognizerResult.MothersName?.ParseStringResult(),
                        Sex = recognizerResult.Sex?.ParseStringResult(),
                        LocalizedName = recognizerResult.LocalizedName?.ParseStringResult(),
                        AdditionalNameInformation = recognizerResult.AdditionalNameInformation?.ParseStringResult(),
                        AdditionalAddressInformation = recognizerResult.AdditionalAddressInformation?.ParseStringResult(),
                        AdditionalOptionalAddressInformation = recognizerResult.AdditionalOptionalAddressInformation?.ParseStringResult(),
                        PlaceOfBirth = recognizerResult.PlaceOfBirth?.ParseStringResult(),
                        Nationality = recognizerResult.Nationality?.ParseStringResult(),
                        Race = recognizerResult.Race?.ParseStringResult(),
                        Religion = recognizerResult.Religion?.ParseStringResult(),
                        Profession = recognizerResult.Profession?.ParseStringResult(),
                        MaritalStatus = recognizerResult.MaritalStatus?.ParseStringResult(),
                        Employer = recognizerResult.Employer?.ParseStringResult(),
                        PersonalIdNumber = recognizerResult.PersonalIdNumber?.ParseStringResult(),
                        DocumentAdditionalNumber = recognizerResult.DocumentAdditionalNumber?.ParseStringResult(),
                        DocumentOptionalAdditionalNumber = recognizerResult.DocumentOptionalAdditionalNumber?.ParseStringResult(),
                        IssuingAuthority = recognizerResult.IssuingAuthority?.ParseStringResult(),
                    };

                    result.DateOfBirth = ParseDateTime(recognizerResult.DateOfBirth);
                    result.DateOfExpiry = ParseDateTime(recognizerResult.DateOfExpiry);
                    result.DateOfIssue = ParseDateTime(recognizerResult.DateOfIssue);
                    
                    result.FaceImage = ParseImage(recognizerResult.FaceImage());
                    result.SignatureImage = ParseImage(recognizerResult.SignatureImage());
                    result.FullDocumentBackImage = ParseImage(recognizerResult.DocumentImage(ScanningSide.Second));
                    result.FullDocumentFrontImage = ParseImage(recognizerResult.DocumentImage(ScanningSide.First));

                    return result;
                }

                return null;
            }
            catch
            {
                return null;
            }    
        }
        
        private static DateTime? ParseDateTime(DateResult? dateResult)
        {
            try
            {
                if (dateResult == null || dateResult.Year == null || dateResult.Month == null || dateResult.Day == null)
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
                if (mBImage == null || mBImage.Bitmap == null || Bitmap.CompressFormat.Jpeg == null)
                    return null;
                
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
                if (mBImage == null || mBImage.Bitmap == null || Bitmap.CompressFormat.Jpeg == null)
                    return null;
                
                var bitmap = mBImage?.Bitmap;
                byte[] bitmapData;
                using (var stream = new MemoryStream())
                {
                    bitmap?.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
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

        public static string ParseStringResult(this StringResult? stringResult)
        {
            return $"{string.Join(" ", stringResult?.GetValues() ?? [])}";
        }
    }
}
