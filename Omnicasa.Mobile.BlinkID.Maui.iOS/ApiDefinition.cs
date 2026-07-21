using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Omnicasa.Mobile.BlinkID.Maui.iOS
{
    // BlinkID 8 for iOS is pure Swift and exports no ObjC classes, so it cannot be
    // bound directly. This binds NativeShim/ instead — see NativeShim/build.sh.

    // @interface OmnBlinkIDDate : NSObject
    [BaseType(typeof(NSObject), Name = "OmnBlinkIDDate")]
    [DisableDefaultCtor]
    interface OmnBlinkIDDate
    {
        // @property (readonly, nonatomic) NSInteger day;
        [Export("day")]
        nint Day { get; }

        // @property (readonly, nonatomic) NSInteger month;
        [Export("month")]
        nint Month { get; }

        // @property (readonly, nonatomic) NSInteger year;
        [Export("year")]
        nint Year { get; }
    }

    // @interface OmnBlinkIDResult : NSObject
    [BaseType(typeof(NSObject), Name = "OmnBlinkIDResult")]
    interface OmnBlinkIDResult
    {
        [NullAllowed, Export("firstName")]
        string FirstName { get; set; }

        [NullAllowed, Export("lastName")]
        string LastName { get; set; }

        [NullAllowed, Export("fullName")]
        string FullName { get; set; }

        [NullAllowed, Export("address")]
        string Address { get; set; }

        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; set; }

        [NullAllowed, Export("fathersName")]
        string FathersName { get; set; }

        [NullAllowed, Export("mothersName")]
        string MothersName { get; set; }

        [NullAllowed, Export("sex")]
        string Sex { get; set; }

        [NullAllowed, Export("localizedName")]
        string LocalizedName { get; set; }

        [NullAllowed, Export("additionalNameInformation")]
        string AdditionalNameInformation { get; set; }

        [NullAllowed, Export("additionalAddressInformation")]
        string AdditionalAddressInformation { get; set; }

        [NullAllowed, Export("additionalOptionalAddressInformation")]
        string AdditionalOptionalAddressInformation { get; set; }

        [NullAllowed, Export("placeOfBirth")]
        string PlaceOfBirth { get; set; }

        [NullAllowed, Export("nationality")]
        string Nationality { get; set; }

        [NullAllowed, Export("race")]
        string Race { get; set; }

        [NullAllowed, Export("religion")]
        string Religion { get; set; }

        [NullAllowed, Export("profession")]
        string Profession { get; set; }

        [NullAllowed, Export("maritalStatus")]
        string MaritalStatus { get; set; }

        [NullAllowed, Export("employer")]
        string Employer { get; set; }

        [NullAllowed, Export("personalIdNumber")]
        string PersonalIdNumber { get; set; }

        [NullAllowed, Export("documentAdditionalNumber")]
        string DocumentAdditionalNumber { get; set; }

        [NullAllowed, Export("documentOptionalAdditionalNumber")]
        string DocumentOptionalAdditionalNumber { get; set; }

        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; set; }

        [NullAllowed, Export("residentialStatus")]
        string ResidentialStatus { get; set; }

        [NullAllowed, Export("documentSubtype")]
        string DocumentSubtype { get; set; }

        [NullAllowed, Export("sponsor")]
        string Sponsor { get; set; }

        [NullAllowed, Export("bloodType")]
        string BloodType { get; set; }

        [NullAllowed, Export("dateOfBirth", ArgumentSemantic.Strong)]
        OmnBlinkIDDate DateOfBirth { get; set; }

        [NullAllowed, Export("dateOfIssue", ArgumentSemantic.Strong)]
        OmnBlinkIDDate DateOfIssue { get; set; }

        [NullAllowed, Export("dateOfExpiry", ArgumentSemantic.Strong)]
        OmnBlinkIDDate DateOfExpiry { get; set; }

        [NullAllowed, Export("faceImage", ArgumentSemantic.Strong)]
        UIImage FaceImage { get; set; }

        [NullAllowed, Export("signatureImage", ArgumentSemantic.Strong)]
        UIImage SignatureImage { get; set; }

        [NullAllowed, Export("frontImage", ArgumentSemantic.Strong)]
        UIImage FrontImage { get; set; }

        [NullAllowed, Export("backImage", ArgumentSemantic.Strong)]
        UIImage BackImage { get; set; }
    }

    // @interface OmnBlinkIDScanner : NSObject
    [BaseType(typeof(NSObject), Name = "OmnBlinkIDScanner")]
    interface OmnBlinkIDScanner
    {
        // +(void)initializeWithLicenseKey:(NSString *)licenseKey completion:(void (^)(NSError *))completion;
        [Static]
        [Export("initializeWithLicenseKey:completion:")]
        void Initialize(string licenseKey, Action<NSError> completion);

        // +(void)presentFrom:(UIViewController *)presenter completion:(void (^)(OmnBlinkIDResult *, NSError *))completion;
        [Static]
        [Export("presentFrom:completion:")]
        void Present(UIViewController presenter, Action<OmnBlinkIDResult, NSError> completion);
    }
}
