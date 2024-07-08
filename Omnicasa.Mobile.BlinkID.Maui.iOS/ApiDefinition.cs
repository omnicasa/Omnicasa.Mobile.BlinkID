using System;
using AVFoundation;
using CoreAnimation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Omnicasa.Mobile.BlinkID.Maui.iOS
{
    // typedef void (^MBBlock)();
    delegate void MBBlock();

    // @interface MBMicroblinkApp : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBMicroblinkApp
    {
        // @property (nonatomic) NSString * language;
        [Export("language")]
        string Language { get; set; }

        // @property (nonatomic) NSBundle * resourcesBundle;
        [Export("resourcesBundle", ArgumentSemantic.Assign)]
        NSBundle ResourcesBundle { get; set; }

        // @property (nonatomic) NSBundle * customResourcesBundle;
        [Export("customResourcesBundle", ArgumentSemantic.Assign)]
        NSBundle CustomResourcesBundle { get; set; }

        // @property (nonatomic) NSString * customLocalizationFileName;
        [Export("customLocalizationFileName")]
        string CustomLocalizationFileName { get; set; }

        // +(instancetype)sharedInstance __attribute__((swift_name("shared()")));
        [Static]
        [Export("sharedInstance")]
        MBMicroblinkApp SharedInstance();

        // -(void)setDefaultLanguage;
        [Export("setDefaultLanguage")]
        void SetDefaultLanguage();

        // -(void)pushStatusBarStyle:(UIStatusBarStyle)statusBarStyle;
        [Export("pushStatusBarStyle:")]
        void PushStatusBarStyle(UIStatusBarStyle statusBarStyle);

        // -(void)popStatusBarStyle;
        [Export("popStatusBarStyle")]
        void PopStatusBarStyle();

        // -(void)pushStatusBarHidden:(BOOL)hidden;
        [Export("pushStatusBarHidden:")]
        void PushStatusBarHidden(bool hidden);

        // -(void)popStatusBarHidden;
        [Export("popStatusBarHidden")]
        void PopStatusBarHidden();

        // -(void)setHelpShown:(BOOL)value;
        [Export("setHelpShown:")]
        void SetHelpShown(bool value);

        // -(BOOL)isHelpShown;
        [Export("isHelpShown")]
        bool IsHelpShown { get; }

        // +(NSBundle *)getDefaultResourcesBundle;
        [Static]
        [Export("getDefaultResourcesBundle")]
        NSBundle DefaultResourcesBundle { get; }
    }

    // @interface MBCameraSettings : NSObject <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBCameraSettings : INSCopying
    {
        // @property (assign, nonatomic) MBCameraPreset cameraPreset;
        [Export("cameraPreset", ArgumentSemantic.Assign)]
        MBCameraPreset CameraPreset { get; set; }

        // @property (assign, nonatomic) MBCameraType cameraType;
        [Export("cameraType", ArgumentSemantic.Assign)]
        MBCameraType CameraType { get; set; }

        // @property (assign, nonatomic) NSTimeInterval autofocusInterval;
        [Export("autofocusInterval")]
        double AutofocusInterval { get; set; }

        // @property (assign, nonatomic) MBCameraAutofocusRestriction cameraAutofocusRestriction;
        [Export("cameraAutofocusRestriction", ArgumentSemantic.Assign)]
        MBCameraAutofocusRestriction CameraAutofocusRestriction { get; set; }

        // @property (nonatomic, weak) NSString * videoGravity;
        [Export("videoGravity", ArgumentSemantic.Weak)]
        string VideoGravity { get; set; }

        // @property (assign, nonatomic) CGPoint focusPoint;
        [Export("focusPoint", ArgumentSemantic.Assign)]
        CGPoint FocusPoint { get; set; }

        // @property (nonatomic) BOOL cameraMirroredHorizontally;
        [Export("cameraMirroredHorizontally")]
        bool CameraMirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL cameraMirroredVertically;
        [Export("cameraMirroredVertically")]
        bool CameraMirroredVertically { get; set; }

        // @property (nonatomic) CGFloat previewZoomScale;
        [Export("previewZoomScale")]
        nfloat PreviewZoomScale { get; set; }

        // -(NSString *)calcSessionPreset;
        [Export("calcSessionPreset")]
        string CalcSessionPreset { get; }

        // -(AVCaptureAutoFocusRangeRestriction)calcAutofocusRangeRestriction;
        [Export("calcAutofocusRangeRestriction")]
        AVCaptureAutoFocusRangeRestriction CalcAutofocusRangeRestriction { get; }
    }

    // typedef void (^MBCaptureHighResImage)(MBImage * _Nullable);
    delegate void MBCaptureHighResImage([NullAllowed] MBImage arg0);

    interface IMBRecognizerRunnerViewController { }

    // @protocol MBRecognizerRunnerViewController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewController
    {
        // @required @property (nonatomic) BOOL autorotate;
        [Abstract]
        [Export("autorotate")]
        bool Autorotate { get; set; }

        // @required @property (nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Abstract]
        [Export("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @required -(void)pauseScanning;
        [Abstract]
        [Export("pauseScanning")]
        void PauseScanning();

        // @required -(BOOL)isScanningPaused;
        [Abstract]
        [Export("isScanningPaused")]
        bool IsScanningPaused { get; }

        // @required -(void)resumeScanningAndResetState:(BOOL)resetState;
        [Abstract]
        [Export("resumeScanningAndResetState:")]
        void ResumeScanningAndResetState(bool resetState);

        // @required -(void)resumeCamera:(void (^ _Nullable)(void))completion;
        [Abstract]
        [Export("resumeCamera:")]
        void ResumeCamera([NullAllowed] Action completion);

        // @required -(BOOL)pauseCamera;
        [Abstract]
        [Export("pauseCamera")]
        bool PauseCamera { get; }

        // @required -(BOOL)isCameraPaused;
        [Abstract]
        [Export("isCameraPaused")]
        bool IsCameraPaused { get; }

        // @required -(void)playScanSuccessSound;
        [Abstract]
        [Export("playScanSuccessSound")]
        void PlayScanSuccessSound();

        // @required -(void)willSetTorchOn:(BOOL)torchOn;
        [Abstract]
        [Export("willSetTorchOn:")]
        void WillSetTorchOn(bool torchOn);

        // @required -(void)resetState;
        [Abstract]
        [Export("resetState")]
        void ResetState();

        // @required -(void)captureHighResImage:(MBCaptureHighResImage _Nonnull)highResoulutionImageCaptured;
        [Abstract]
        [Export("captureHighResImage:")]
        void CaptureHighResImage(MBCaptureHighResImage highResoulutionImageCaptured);
    }

    interface IMBOverlayContainerViewController { }

    // @protocol MBOverlayContainerViewController <MBRecognizerRunnerViewController>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface MBOverlayContainerViewController : MBRecognizerRunnerViewController
    {
        // @required -(void)overlayViewControllerWillCloseCamera:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerWillCloseCamera:")]
        void OverlayViewControllerWillCloseCamera(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewControllerShouldDisplayTorch:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerShouldDisplayTorch:")]
        bool OverlayViewControllerShouldDisplayTorch(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewController:(MBOverlayViewController *)overlayViewController willSetTorch:(BOOL)isTorchOn;
        [Abstract]
        [Export("overlayViewController:willSetTorch:")]
        bool OverlayViewController(MBOverlayViewController overlayViewController, bool isTorchOn);

        // @required -(BOOL)shouldDisplayHelpButton;
        [Abstract]
        [Export("shouldDisplayHelpButton")]
        bool ShouldDisplayHelpButton { get; }

        // @required -(BOOL)isStatusBarPresented;
        [Abstract]
        [Export("isStatusBarPresented")]
        bool IsStatusBarPresented { get; }

        // @required -(BOOL)isTorchOn;
        [Abstract]
        [Export("isTorchOn")]
        bool IsTorchOn { get; }

        // @required -(BOOL)isCameraAuthorized;
        [Abstract]
        [Export("isCameraAuthorized")]
        bool IsCameraAuthorized { get; }
    }

    // @interface MBOverlayViewController : UIViewController
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(UIViewController))]
    [DisableDefaultCtor]
    interface MBOverlayViewController
    {
        // @property (nonatomic, weak) UIViewController<MBOverlayContainerViewController> * _Nullable recognizerRunnerViewController;
        [NullAllowed, Export("recognizerRunnerViewController", ArgumentSemantic.Weak)]
        IMBOverlayContainerViewController RecognizerRunnerViewController { get; set; }
    }

    // @interface MBRecognizerResult : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerResult
    {
        // @property (readonly, assign, nonatomic) MBRecognizerResultState resultState;
        [Export("resultState", ArgumentSemantic.Assign)]
        MBRecognizerResultState ResultState { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull resultStateString;
        [Export("resultStateString")]
        string ResultStateString { get; }
    }

    // @protocol MBNativeResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBNativeResult
    {
        // @required -(NSObject * _Nullable)nativeResult;
        [Abstract]
        [NullAllowed, Export("nativeResult")]
        NSObject NativeResult { get; }

        // @required -(NSString * _Nullable)stringResult;
        [Abstract]
        [NullAllowed, Export("stringResult")]
        string StringResult { get; }
    }

    // @interface MBDateResult : NSObject <MBNativeResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDateResult : IMBNativeResult
    {
        // -(instancetype _Nonnull)initWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateStringResult:(MBStringResult * _Nullable)originalDateStringResult isFilledByDomainKnowledge:(BOOL)isFilledByDomainKnowledge __attribute__((objc_designated_initializer));
        [Export("initWithDay:month:year:originalDateStringResult:isFilledByDomainKnowledge:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint day, nint month, nint year, [NullAllowed] MBStringResult originalDateStringResult, bool isFilledByDomainKnowledge);

        // @property (readonly, nonatomic) MBStringResult * _Nullable originalDateStringResult;
        [NullAllowed, Export("originalDateStringResult")]
        MBStringResult OriginalDateStringResult { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable date;
        [NullAllowed, Export("date")]
        NSDate Date { get; }

        // @property (readonly, assign, nonatomic) NSInteger day;
        [Export("day")]
        nint Day { get; }

        // @property (readonly, assign, nonatomic) NSInteger month;
        [Export("month")]
        nint Month { get; }

        // @property (readonly, assign, nonatomic) NSInteger year;
        [Export("year")]
        nint Year { get; }

        // @property (readonly, nonatomic) BOOL isFilledByDomainKnowledge;
        [Export("isFilledByDomainKnowledge")]
        bool IsFilledByDomainKnowledge { get; }

        // +(instancetype _Nonnull)dateResultWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateStringResult:(MBStringResult * _Nullable)originalDateStringResult isFilledByDomainKnowledge:(BOOL)isFilledByDomainKnowledge;
        [Static]
        [Export("dateResultWithDay:month:year:originalDateStringResult:isFilledByDomainKnowledge:")]
        MBDateResult DateResultWithDay(nint day, nint month, nint year, [NullAllowed] MBStringResult originalDateStringResult, bool isFilledByDomainKnowledge);
    }

    // @interface MBDate : NSObject <MBNativeResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDate : IMBNativeResult
    {
        // -(instancetype _Nonnull)initWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString isFilledByDomainKnowledge:(BOOL)isFilledByDomainKnowledge __attribute__((objc_designated_initializer));
        [Export("initWithDay:month:year:originalDateString:isFilledByDomainKnowledge:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint day, nint month, nint year, [NullAllowed] string originalDateString, bool isFilledByDomainKnowledge);

        // @property (readonly, nonatomic) NSString * _Nullable originalDateString;
        [NullAllowed, Export("originalDateString")]
        string OriginalDateString { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable date;
        [NullAllowed, Export("date")]
        NSDate Date { get; }

        // @property (readonly, assign, nonatomic) NSInteger day;
        [Export("day")]
        nint Day { get; }

        // @property (readonly, assign, nonatomic) NSInteger month;
        [Export("month")]
        nint Month { get; }

        // @property (readonly, assign, nonatomic) NSInteger year;
        [Export("year")]
        nint Year { get; }

        // @property (readonly, nonatomic) BOOL isFilledByDomainKnowledge;
        [Export("isFilledByDomainKnowledge")]
        bool IsFilledByDomainKnowledge { get; }

        // +(instancetype _Nonnull)dateWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString isFilledByDomainKnowledge:(BOOL)isFilledByDomainKnowledge;
        [Static]
        [Export("dateWithDay:month:year:originalDateString:isFilledByDomainKnowledge:")]
        MBDate DateWithDay(nint day, nint month, nint year, [NullAllowed] string originalDateString, bool isFilledByDomainKnowledge);
    }

    // @protocol MBAgeResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBAgeResult
    {
        // @required @property (readonly, nonatomic) NSInteger age;
        [Abstract]
        [Export("age")]
        nint Age { get; }

        // @required -(MBAgeLimitStatus)getAgeLimitStatusFor:(NSInteger)ageLimit;
        [Abstract]
        [Export("getAgeLimitStatusFor:")]
        MBAgeLimitStatus GetAgeLimitStatusFor(nint ageLimit);
    }

    // @interface MBMrzResult : NSObject <MBAgeResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBMrzResult : IMBAgeResult
    {
        // @property (readonly, assign, nonatomic) MBMrtdDocumentType documentType;
        [Export("documentType", ArgumentSemantic.Assign)]
        MBMrtdDocumentType DocumentType { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull primaryID;
        [Export("primaryID", ArgumentSemantic.Strong)]
        string PrimaryID { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull secondaryID;
        [Export("secondaryID", ArgumentSemantic.Strong)]
        string SecondaryID { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull issuer;
        [Export("issuer", ArgumentSemantic.Strong)]
        string Issuer { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull issuerName;
        [Export("issuerName", ArgumentSemantic.Strong)]
        string IssuerName { get; }

        // @property (readonly, nonatomic, strong) MBDate * _Nonnull dateOfBirth;
        [Export("dateOfBirth", ArgumentSemantic.Strong)]
        MBDate DateOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentNumber;
        [Export("documentNumber", ArgumentSemantic.Strong)]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull nationality;
        [Export("nationality", ArgumentSemantic.Strong)]
        string Nationality { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull gender;
        [Export("gender", ArgumentSemantic.Strong)]
        string Gender { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentCode;
        [Export("documentCode", ArgumentSemantic.Strong)]
        string DocumentCode { get; }

        // @property (readonly, nonatomic, strong) MBDate * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry", ArgumentSemantic.Strong)]
        MBDate DateOfExpiry { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull opt1;
        [Export("opt1", ArgumentSemantic.Strong)]
        string Opt1 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull opt2;
        [Export("opt2", ArgumentSemantic.Strong)]
        string Opt2 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull alienNumber;
        [Export("alienNumber", ArgumentSemantic.Strong)]
        string AlienNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull applicationReceiptNumber;
        [Export("applicationReceiptNumber", ArgumentSemantic.Strong)]
        string ApplicationReceiptNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull immigrantCaseNumber;
        [Export("immigrantCaseNumber", ArgumentSemantic.Strong)]
        string ImmigrantCaseNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull mrzText;
        [Export("mrzText", ArgumentSemantic.Strong)]
        string MrzText { get; }

        // @property (readonly, assign, nonatomic) BOOL isParsed;
        [Export("isParsed")]
        bool IsParsed { get; }

        // @property (readonly, assign, nonatomic) BOOL isVerified;
        [Export("isVerified")]
        bool IsVerified { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedOpt1;
        [Export("sanitizedOpt1", ArgumentSemantic.Strong)]
        string SanitizedOpt1 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedOpt2;
        [Export("sanitizedOpt2", ArgumentSemantic.Strong)]
        string SanitizedOpt2 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedNationality;
        [Export("sanitizedNationality", ArgumentSemantic.Strong)]
        string SanitizedNationality { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedIssuer;
        [Export("sanitizedIssuer", ArgumentSemantic.Strong)]
        string SanitizedIssuer { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedDocumentCode;
        [Export("sanitizedDocumentCode", ArgumentSemantic.Strong)]
        string SanitizedDocumentCode { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedDocumentNumber;
        [Export("sanitizedDocumentNumber", ArgumentSemantic.Strong)]
        string SanitizedDocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull nationalityName;
        [Export("nationalityName", ArgumentSemantic.Strong)]
        string NationalityName { get; }
    }

    // @interface MBBarcodeElements : NSObject <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBBarcodeElements : INSCopying
    {
        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }

        // -(NSString * _Nonnull)getValue:(MBBarcodeElementKey)key;
        [Export("getValue:")]
        string GetValue(MBBarcodeElementKey key);
    }

    // @interface MBBarcodeResult : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBBarcodeResult
    {
        // @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
        [NullAllowed, Export("rawData", ArgumentSemantic.Strong)]
        NSData RawData { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
        [NullAllowed, Export("stringData", ArgumentSemantic.Strong)]
        string StringData { get; }

        // @property (readonly, assign, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { get; }

        // @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
        [Export("barcodeType", ArgumentSemantic.Assign)]
        MBBarcodeType BarcodeType { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull middleName;
        [Export("middleName")]
        string MiddleName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull additionalNameInformation;
        [Export("additionalNameInformation")]
        string AdditionalNameInformation { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull race;
        [Export("race")]
        string Race { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull profession;
        [Export("profession")]
        string Profession { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
        [Export("maritalStatus")]
        string MaritalStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull residentialStatus;
        [Export("residentialStatus")]
        string ResidentialStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull employer;
        [Export("employer")]
        string Employer { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) MBDate * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDate DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDate * _Nonnull dateOfIssue;
        [Export("dateOfIssue")]
        MBDate DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDate * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull personalIdNumber;
        [Export("personalIdNumber")]
        string PersonalIdNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentAdditionalNumber;
        [Export("documentAdditionalNumber")]
        string DocumentAdditionalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull postalCode;
        [Export("postalCode")]
        string PostalCode { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull jurisdiction;
        [Export("jurisdiction")]
        string Jurisdiction { get; }

        // @property (readonly, nonatomic) MBBarcodeDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
        [NullAllowed, Export("driverLicenseDetailedInfo")]
        MBBarcodeDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }

        // @property (readonly, nonatomic) MBBarcodeElements * _Nullable extendedElements;
        [NullAllowed, Export("extendedElements")]
        MBBarcodeElements ExtendedElements { get; }
    }

    // @interface MBDriverLicenseDetailedInfo : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDriverLicenseDetailedInfo
    {
        // @property (readonly, nonatomic) MBStringResult * _Nullable restrictions;
        [NullAllowed, Export("restrictions")]
        MBStringResult Restrictions { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable endorsements;
        [NullAllowed, Export("endorsements")]
        MBStringResult Endorsements { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable vehicleClass;
        [NullAllowed, Export("vehicleClass")]
        MBStringResult VehicleClass { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable conditions;
        [NullAllowed, Export("conditions")]
        MBStringResult Conditions { get; }

        // @property (readonly, nonatomic) NSArray<MBVehicleClassInfo *> * _Nullable vehicleClassesInfo;
        [NullAllowed, Export("vehicleClassesInfo")]
        MBVehicleClassInfo[] VehicleClassesInfo { get; }
    }

    // @interface MBVizResult : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVizResult
    {
        // @property (readonly, nonatomic) MBStringResult * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        MBStringResult FirstName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        MBStringResult LastName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable fullName;
        [NullAllowed, Export("fullName")]
        MBStringResult FullName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable fathersName;
        [NullAllowed, Export("fathersName")]
        MBStringResult FathersName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable mothersName;
        [NullAllowed, Export("mothersName")]
        MBStringResult MothersName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalNameInformation;
        [NullAllowed, Export("additionalNameInformation")]
        MBStringResult AdditionalNameInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable localizedName;
        [NullAllowed, Export("localizedName")]
        MBStringResult LocalizedName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable address;
        [NullAllowed, Export("address")]
        MBStringResult Address { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalAddressInformation;
        [NullAllowed, Export("additionalAddressInformation")]
        MBStringResult AdditionalAddressInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalOptionalAddressInformation;
        [NullAllowed, Export("additionalOptionalAddressInformation")]
        MBStringResult AdditionalOptionalAddressInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        MBStringResult PlaceOfBirth { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        MBStringResult Nationality { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable race;
        [NullAllowed, Export("race")]
        MBStringResult Race { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable religion;
        [NullAllowed, Export("religion")]
        MBStringResult Religion { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable profession;
        [NullAllowed, Export("profession")]
        MBStringResult Profession { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable maritalStatus;
        [NullAllowed, Export("maritalStatus")]
        MBStringResult MaritalStatus { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable residentialStatus;
        [NullAllowed, Export("residentialStatus")]
        MBStringResult ResidentialStatus { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable employer;
        [NullAllowed, Export("employer")]
        MBStringResult Employer { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable sex;
        [NullAllowed, Export("sex")]
        MBStringResult Sex { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        MBStringResult DocumentNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable personalIdNumber;
        [NullAllowed, Export("personalIdNumber")]
        MBStringResult PersonalIdNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentAdditionalNumber;
        [NullAllowed, Export("documentAdditionalNumber")]
        MBStringResult DocumentAdditionalNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentOptionalAdditionalNumber;
        [NullAllowed, Export("documentOptionalAdditionalNumber")]
        MBStringResult DocumentOptionalAdditionalNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalPersonalIdNumber;
        [NullAllowed, Export("additionalPersonalIdNumber")]
        MBStringResult AdditionalPersonalIdNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        MBStringResult IssuingAuthority { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentSubtype;
        [NullAllowed, Export("documentSubtype")]
        MBStringResult DocumentSubtype { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable sponsor;
        [NullAllowed, Export("sponsor")]
        MBStringResult Sponsor { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable bloodType;
        [NullAllowed, Export("bloodType")]
        MBStringResult BloodType { get; }

        // @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
        [NullAllowed, Export("driverLicenseDetailedInfo")]
        MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }
    }

    // @protocol MBCombinedRecognizerResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    public interface IMBCombinedRecognizerResult { }

    [Protocol]
    interface MBCombinedRecognizerResult
    {
        // @required @property (readonly, assign, nonatomic) BOOL scanningFirstSideDone;
        [Abstract]
        [Export("scanningFirstSideDone")]
        bool ScanningFirstSideDone { get; }

        // @optional @property (readonly, assign, nonatomic) MBDataMatchState documentDataMatch;
        [Export("documentDataMatch", ArgumentSemantic.Assign)]
        MBDataMatchState DocumentDataMatch { get; }
    }

    // @interface MBImage : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBImage
    {
        // @property (readonly, nonatomic) UIImage * _Nullable image;
        [NullAllowed, Export("image")]
        UIImage Image { get; }

        // @property (nonatomic) CGRect roi;
        [Export("roi", ArgumentSemantic.Assign)]
        CGRect Roi { get; set; }

        // @property (nonatomic) MBProcessingOrientation orientation;
        [Export("orientation", ArgumentSemantic.Assign)]
        MBProcessingOrientation Orientation { get; set; }

        // @property (nonatomic) BOOL mirroredHorizontally;
        [Export("mirroredHorizontally")]
        bool MirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL mirroredVertically;
        [Export("mirroredVertically")]
        bool MirroredVertically { get; set; }

        // @property (nonatomic) BOOL estimateFrameQuality;
        [Export("estimateFrameQuality")]
        bool EstimateFrameQuality { get; set; }

        // @property (nonatomic) BOOL cameraFrame;
        [Export("cameraFrame")]
        bool CameraFrame { get; set; }

        // @property (nonatomic) MBVideoRotationAngle videoRotationAngle;
        [Export("videoRotationAngle", ArgumentSemantic.Assign)]
        MBVideoRotationAngle VideoRotationAngle { get; set; }

        // +(instancetype _Nonnull)imageWithUIImage:(UIImage * _Nonnull)image;
        [Static]
        [Export("imageWithUIImage:")]
        MBImage ImageWithUIImage(UIImage image);

        // +(instancetype _Nonnull)imageWithCmSampleBuffer:(CMSampleBufferRef _Nonnull)buffer;
        [Static]
        [Export("imageWithCmSampleBuffer:")]
        MBImage ImageWithCmSampleBuffer(CMSampleBuffer buffer);

        // +(instancetype _Nonnull)imageWithCvPixelBuffer:(CVPixelBufferRef _Nonnull)buffer orientation:(UIImageOrientation)orientation;
        [Static]
        [Export("imageWithCvPixelBuffer:orientation:")]
        MBImage ImageWithCvPixelBuffer(CVPixelBuffer buffer, UIImageOrientation orientation);
    }

    // @interface MBStringResult : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBStringResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull value;
        [Export("value")]
        string Value { get; }

        // -(NSString * _Nonnull)valueForAlphabetType:(MBAlphabetType)alphabetType;
        [Export("valueForAlphabetType:")]
        string ValueForAlphabetType(MBAlphabetType alphabetType);

        // @property (readonly, nonatomic) CGRect location;
        [Export("location")]
        CGRect Location { get; }

        // -(CGRect)locationForAlphabetType:(MBAlphabetType)alphabetType;
        [Export("locationForAlphabetType:")]
        CGRect LocationForAlphabetType(MBAlphabetType alphabetType);

        // @property (readonly, nonatomic) MBSide side;
        [Export("side")]
        MBSide Side { get; }

        // -(MBSide)sideForAlphabetType:(MBAlphabetType)alphabetType;
        [Export("sideForAlphabetType:")]
        MBSide SideForAlphabetType(MBAlphabetType alphabetType);
    }

    // @protocol MBFaceImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBFaceImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable faceImage;
        [Abstract]
        [NullAllowed, Export("faceImage")]
        MBImage FaceImage { get; }
    }

    // @protocol MBEncodedFaceImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBEncodedFaceImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFaceImage;
        [Abstract]
        [NullAllowed, Export("encodedFaceImage")]
        NSData EncodedFaceImage { get; }
    }

    // @protocol MBCombinedFullDocumentImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBCombinedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentFrontImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentFrontImage")]
        MBImage FullDocumentFrontImage { get; }

        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentBackImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentBackImage")]
        MBImage FullDocumentBackImage { get; }
    }

    // @protocol MBEncodedCombinedFullDocumentImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBEncodedCombinedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentFrontImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentFrontImage")]
        NSData EncodedFullDocumentFrontImage { get; }

        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentBackImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentBackImage")]
        NSData EncodedFullDocumentBackImage { get; }
    }

    // @protocol MBSignatureImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBSignatureImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable signatureImage;
        [Abstract]
        [NullAllowed, Export("signatureImage")]
        MBImage SignatureImage { get; }
    }

    // @protocol MBEncodedSignatureImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBEncodedSignatureImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedSignatureImage;
        [Abstract]
        [NullAllowed, Export("encodedSignatureImage")]
        NSData EncodedSignatureImage { get; }
    }

    // @interface MBClassInfo : NSObject <NSSecureCoding>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBClassInfo : INSSecureCoding
    {
        // @property (readonly, assign, nonatomic) MBCountry country;
        [Export("country", ArgumentSemantic.Assign)]
        MBCountry Country { get; }

        // @property (readonly, assign, nonatomic) MBRegion region;
        [Export("region", ArgumentSemantic.Assign)]
        MBRegion Region { get; }

        // @property (readonly, assign, nonatomic) MBType type;
        [Export("type", ArgumentSemantic.Assign)]
        MBType Type { get; }

        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable countryName;
        [NullAllowed, Export("countryName")]
        string CountryName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable isoNumericCountryCode;
        [NullAllowed, Export("isoNumericCountryCode")]
        string IsoNumericCountryCode { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable isoAlpha2CountryCode;
        [NullAllowed, Export("isoAlpha2CountryCode")]
        string IsoAlpha2CountryCode { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable isoAlpha3CountryCode;
        [NullAllowed, Export("isoAlpha3CountryCode")]
        string IsoAlpha3CountryCode { get; }
    }

    // @interface MBImageAnalysisResult : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBImageAnalysisResult
    {
        // @property (readonly, assign, nonatomic) BOOL blurDetected;
        [Export("blurDetected")]
        bool BlurDetected { get; }

        // @property (readonly, assign, nonatomic) BOOL glareDetected;
        [Export("glareDetected")]
        bool GlareDetected { get; }

        // @property (readonly, assign, nonatomic) MBDocumentImageColorStatus documentImageColorStatus;
        [Export("documentImageColorStatus", ArgumentSemantic.Assign)]
        MBDocumentImageColorStatus DocumentImageColorStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus documentImageMoireStatus;
        [Export("documentImageMoireStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus DocumentImageMoireStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus faceDetectionStatus;
        [Export("faceDetectionStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus FaceDetectionStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus mrzDetectionStatus;
        [Export("mrzDetectionStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus MrzDetectionStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus barcodeDetectionStatus;
        [Export("barcodeDetectionStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus BarcodeDetectionStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus realIDDetectionStatus;
        [Export("realIDDetectionStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus RealIDDetectionStatus { get; }

        // @property (readonly, assign, nonatomic) MBCardOrientation cardOrientation;
        [Export("cardOrientation", ArgumentSemantic.Assign)]
        MBCardOrientation CardOrientation { get; }

        // @property (readonly, assign, nonatomic) MBRotation cardRotation;
        [Export("cardRotation", ArgumentSemantic.Assign)]
        MBRotation CardRotation { get; }
    }

    // @protocol MBDocumentExpirationCheckResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBDocumentExpirationCheckResult
    {
        // @required @property (readonly, nonatomic) BOOL expired __attribute__((swift_name("isExpired")));
        [Abstract]
        [Export("expired")]
        bool Expired { get; }
    }

    // @interface MBFieldState : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBFieldState
    {
        // @property (nonatomic) MBDataMatchField field;
        [Export("field", ArgumentSemantic.Assign)]
        MBDataMatchField Field { get; set; }

        // @property (nonatomic) MBDataMatchState state;
        [Export("state", ArgumentSemantic.Assign)]
        MBDataMatchState State { get; set; }

        // -(instancetype _Nonnull)initWithField:(MBDataMatchField)field state:(MBDataMatchState)state;
        [Export("initWithField:state:")]
        IntPtr Constructor(MBDataMatchField field, MBDataMatchState state);
    }

    // @interface MBDataMatchResult : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDataMatchResult
    {
        // @property (readonly, nonatomic) NSArray<MBFieldState *> * _Nonnull states;
        [Export("states")]
        MBFieldState[] States { get; }

        // @property (readonly, nonatomic) MBDataMatchState stateForWholeDocument;
        [Export("stateForWholeDocument")]
        MBDataMatchState StateForWholeDocument { get; }

        // -(MBDataMatchState)getStateForField:(MBDataMatchField)field;
        [Export("getStateForField:")]
        MBDataMatchState GetStateForField(MBDataMatchField field);
    }

    // @interface MBAdditionalProcessingInfo : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBAdditionalProcessingInfo
    {
        // @property (readonly, nonatomic) NSArray<NSNumber *> * _Nonnull missingMandatoryFields;
        [Export("missingMandatoryFields")]
        NSNumber[] MissingMandatoryFields { get; }

        // @property (readonly, nonatomic) NSArray<NSNumber *> * _Nonnull invalidCharacterFields;
        [Export("invalidCharacterFields")]
        NSNumber[] InvalidCharacterFields { get; }

        // @property (readonly, nonatomic) NSArray<NSNumber *> * _Nonnull extraPresentFields;
        [Export("extraPresentFields")]
        NSNumber[] ExtraPresentFields { get; }
    }

    // @interface MBBlinkIdMultiSideRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBEncodedFaceImageResult, MBCombinedFullDocumentImageResult, MBEncodedCombinedFullDocumentImageResult, MBAgeResult, MBDocumentExpirationCheckResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBlinkIdMultiSideRecognizerResult : INSCopying, IMBCombinedRecognizerResult, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBCombinedFullDocumentImageResult, IMBEncodedCombinedFullDocumentImageResult, IMBAgeResult, IMBDocumentExpirationCheckResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBStringResult * _Nullable address;
        [NullAllowed, Export("address")]
        MBStringResult Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) BOOL dateOfExpiryPermanent;
        [Export("dateOfExpiryPermanent")]
        bool DateOfExpiryPermanent { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        MBStringResult DocumentNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        MBStringResult FirstName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable fullName;
        [NullAllowed, Export("fullName")]
        MBStringResult FullName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        MBStringResult LastName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable fathersName;
        [NullAllowed, Export("fathersName")]
        MBStringResult FathersName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable mothersName;
        [NullAllowed, Export("mothersName")]
        MBStringResult MothersName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable sex;
        [NullAllowed, Export("sex")]
        MBStringResult Sex { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable localizedName;
        [NullAllowed, Export("localizedName")]
        MBStringResult LocalizedName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalNameInformation;
        [NullAllowed, Export("additionalNameInformation")]
        MBStringResult AdditionalNameInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalAddressInformation;
        [NullAllowed, Export("additionalAddressInformation")]
        MBStringResult AdditionalAddressInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalOptionalAddressInformation;
        [NullAllowed, Export("additionalOptionalAddressInformation")]
        MBStringResult AdditionalOptionalAddressInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        MBStringResult PlaceOfBirth { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        MBStringResult Nationality { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable race;
        [NullAllowed, Export("race")]
        MBStringResult Race { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable religion;
        [NullAllowed, Export("religion")]
        MBStringResult Religion { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable profession;
        [NullAllowed, Export("profession")]
        MBStringResult Profession { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable maritalStatus;
        [NullAllowed, Export("maritalStatus")]
        MBStringResult MaritalStatus { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable residentialStatus;
        [NullAllowed, Export("residentialStatus")]
        MBStringResult ResidentialStatus { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable employer;
        [NullAllowed, Export("employer")]
        MBStringResult Employer { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable personalIdNumber;
        [NullAllowed, Export("personalIdNumber")]
        MBStringResult PersonalIdNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentAdditionalNumber;
        [NullAllowed, Export("documentAdditionalNumber")]
        MBStringResult DocumentAdditionalNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentOptionalAdditionalNumber;
        [NullAllowed, Export("documentOptionalAdditionalNumber")]
        MBStringResult DocumentOptionalAdditionalNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        MBStringResult IssuingAuthority { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentSubtype;
        [NullAllowed, Export("documentSubtype")]
        MBStringResult DocumentSubtype { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable sponsor;
        [NullAllowed, Export("sponsor")]
        MBStringResult Sponsor { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable bloodType;
        [NullAllowed, Export("bloodType")]
        MBStringResult BloodType { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nullable mrzResult;
        [NullAllowed, Export("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
        [NullAllowed, Export("driverLicenseDetailedInfo")]
        MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

        // @property (readonly, nonatomic) MBClassInfo * _Nullable classInfo;
        [NullAllowed, Export("classInfo")]
        MBClassInfo ClassInfo { get; }

        // @property (readonly, nonatomic) MBImageAnalysisResult * _Nullable frontImageAnalysisResult;
        [NullAllowed, Export("frontImageAnalysisResult")]
        MBImageAnalysisResult FrontImageAnalysisResult { get; }

        // @property (readonly, nonatomic) MBImageAnalysisResult * _Nullable backImageAnalysisResult;
        [NullAllowed, Export("backImageAnalysisResult")]
        MBImageAnalysisResult BackImageAnalysisResult { get; }

        // @property (readonly, nonatomic) MBBarcodeResult * _Nullable barcodeResult;
        [NullAllowed, Export("barcodeResult")]
        MBBarcodeResult BarcodeResult { get; }

        // @property (readonly, nonatomic) MBVizResult * _Nullable frontVizResult;
        [NullAllowed, Export("frontVizResult")]
        MBVizResult FrontVizResult { get; }

        // @property (readonly, nonatomic) MBVizResult * _Nullable backVizResult;
        [NullAllowed, Export("backVizResult")]
        MBVizResult BackVizResult { get; }

        // @property (readonly, assign, nonatomic) MBProcessingStatus processingStatus;
        [Export("processingStatus", ArgumentSemantic.Assign)]
        MBProcessingStatus ProcessingStatus { get; }

        // @property (readonly, assign, nonatomic) MBProcessingStatus frontProcessingStatus;
        [Export("frontProcessingStatus", ArgumentSemantic.Assign)]
        MBProcessingStatus FrontProcessingStatus { get; }

        // @property (readonly, assign, nonatomic) MBProcessingStatus backProcessingStatus;
        [Export("backProcessingStatus", ArgumentSemantic.Assign)]
        MBProcessingStatus BackProcessingStatus { get; }

        // @property (readonly, nonatomic) MBAdditionalProcessingInfo * _Nullable frontAdditionalProcessingInfo;
        [NullAllowed, Export("frontAdditionalProcessingInfo")]
        MBAdditionalProcessingInfo FrontAdditionalProcessingInfo { get; }

        // @property (readonly, nonatomic) MBAdditionalProcessingInfo * _Nullable backAdditionalProcessingInfo;
        [NullAllowed, Export("backAdditionalProcessingInfo")]
        MBAdditionalProcessingInfo BackAdditionalProcessingInfo { get; }

        // @property (readonly, assign, nonatomic) MBRecognitionMode recognitionMode;
        [Export("recognitionMode", ArgumentSemantic.Assign)]
        MBRecognitionMode RecognitionMode { get; }

        // @property (readonly, nonatomic) MBImage * _Nullable frontCameraFrame;
        [NullAllowed, Export("frontCameraFrame")]
        MBImage FrontCameraFrame { get; }

        // @property (readonly, nonatomic) MBImage * _Nullable backCameraFrame;
        [NullAllowed, Export("backCameraFrame")]
        MBImage BackCameraFrame { get; }

        // @property (readonly, nonatomic) MBImage * _Nullable barcodeCameraFrame;
        [NullAllowed, Export("barcodeCameraFrame")]
        MBImage BarcodeCameraFrame { get; }

        // @property (readonly, nonatomic) MBDataMatchResult * _Nullable dataMatchResult;
        [NullAllowed, Export("dataMatchResult")]
        MBDataMatchResult DataMatchResult { get; }

        // @property (readonly, nonatomic) CGRect faceImageLocation;
        [Export("faceImageLocation")]
        CGRect FaceImageLocation { get; }

        // @property (readonly, nonatomic) MBSide faceImageSide;
        [Export("faceImageSide")]
        MBSide FaceImageSide { get; }
    }

    // typedef void (^MBScanningResultBlock)(MBBlinkIdMultiSideRecognizerResult * _Nonnull);
    delegate void MBScanningResultBlock(MBBlinkIdMultiSideRecognizerResult arg0);

    // typedef void (^MBScanningOverlayCloseButtonTappedBlock)();
    delegate void MBScanningOverlayCloseButtonTappedBlock();

    // @interface MBViewControllerFactory : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBViewControllerFactory
    {
        // +(UIViewController<MBRecognizerRunnerViewController> * _Nullable)recognizerRunnerViewControllerWithOverlayViewController:(MBOverlayViewController * _Nonnull)overlayViewController __attribute__((swift_name("recognizerRunnerViewController(withOverlayViewController:)")));
        [Static]
        [Export("recognizerRunnerViewControllerWithOverlayViewController:")]
        [return: NullAllowed]
        IMBRecognizerRunnerViewController RecognizerRunnerViewControllerWithOverlayViewController(MBOverlayViewController overlayViewController);

        // +(UIViewController<MBRecognizerRunnerViewController> * _Nullable)recognizerRunnerViewControllerWithResult:(MBScanningResultBlock _Nonnull)result closeButtonTapped:(MBScanningOverlayCloseButtonTappedBlock _Nonnull)closeButtonTapped __attribute__((swift_name("recognizerRunnerViewController(withResult:closeButtonTapped:)")));
        [Static]
        [Export("recognizerRunnerViewControllerWithResult:closeButtonTapped:")]
        [return: NullAllowed]
        IMBRecognizerRunnerViewController RecognizerRunnerViewControllerWithResult(MBScanningResultBlock result, MBScanningOverlayCloseButtonTappedBlock closeButtonTapped);
    }

    [Static]
    partial interface Constants
    {
        /*
        // extern NSString *const MBLicenseErrorNotification;
        [Field("MBLicenseErrorNotification", "__Internal")]
        NSString MBLicenseErrorNotification { get; }
        */
    }

    // typedef void (^MBLicenseErrorBlock)(MBLicenseError);
    delegate void MBLicenseErrorBlock(MBLicenseError arg0);

    // @interface MBMicroblinkSDK : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBMicroblinkSDK
    {
        // +(instancetype _Nonnull)sharedInstance __attribute__((swift_name("shared()")));
        [Static]
        [Export("sharedInstance")]
        MBMicroblinkSDK SharedInstance();

        // @property (assign, nonatomic) BOOL showTrialLicenseWarning;
        [Export("showTrialLicenseWarning")]
        bool ShowTrialLicenseWarning { get; set; }

        // -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer errorCallback:(MBLicenseErrorBlock _Nonnull)errorCallback;
        [Export("setLicenseBuffer:errorCallback:")]
        void SetLicenseBuffer(NSData licenseBuffer, MBLicenseErrorBlock errorCallback);

        // -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer andLicensee:(NSString * _Nonnull)licensee errorCallback:(MBLicenseErrorBlock _Nonnull)errorCallback;
        [Export("setLicenseBuffer:andLicensee:errorCallback:")]
        void SetLicenseBuffer(NSData licenseBuffer, string licensee, MBLicenseErrorBlock errorCallback);

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey errorCallback:(MBLicenseErrorBlock _Nonnull)errorCallback;
        [Export("setLicenseKey:errorCallback:")]
        void SetLicenseKey(string base64LicenseKey, MBLicenseErrorBlock errorCallback);

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey andLicensee:(NSString * _Nonnull)licensee errorCallback:(MBLicenseErrorBlock _Nonnull)errorCallback;
        [Export("setLicenseKey:andLicensee:errorCallback:")]
        void SetLicenseKey(string base64LicenseKey, string licensee, MBLicenseErrorBlock errorCallback);

        // -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle errorCallback:(MBLicenseErrorBlock _Nonnull)errorCallback;
        [Export("setLicenseResource:withExtension:inSubdirectory:forBundle:errorCallback:")]
        void SetLicenseResource(string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle, MBLicenseErrorBlock errorCallback);

        // -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle andLicensee:(NSString * _Nonnull)licensee errorCallback:(MBLicenseErrorBlock _Nonnull)errorCallback;
        [Export("setLicenseResource:withExtension:inSubdirectory:forBundle:andLicensee:errorCallback:")]
        void SetLicenseResource(string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle, string licensee, MBLicenseErrorBlock errorCallback);

        // +(NSString * _Nonnull)buildVersionString;
        [Static]
        [Export("buildVersionString")]
        string BuildVersionString { get; }

        // +(BOOL)isScanningUnsupportedForCameraType:(MBCameraType)type error:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("none")));
        [Static]
        [Export("isScanningUnsupportedForCameraType:error:")]
        bool IsScanningUnsupportedForCameraType(MBCameraType type, [NullAllowed] out NSError error);

        // -(void)setPingProxyUrl:(NSString * _Nonnull)urlString;
        [Export("setPingProxyUrl:")]
        void SetPingProxyUrl(string urlString);
    }

    // @interface MBProductIntegrationInfo : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBProductIntegrationInfo
    {
        // +(instancetype _Nonnull)sharedInstance __attribute__((swift_name("shared()")));
        [Static]
        [Export("sharedInstance")]
        MBProductIntegrationInfo SharedInstance();

        // @property (readonly, nonatomic, strong) NSString * _Nonnull product;
        [Export("product", ArgumentSemantic.Strong)]
        string Product { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull productVersion;
        [Export("productVersion", ArgumentSemantic.Strong)]
        string ProductVersion { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull packageName;
        [Export("packageName", ArgumentSemantic.Strong)]
        string PackageName { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull platform;
        [Export("platform", ArgumentSemantic.Strong)]
        string Platform { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull osVersion;
        [Export("osVersion", ArgumentSemantic.Strong)]
        string OsVersion { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull device;
        [Export("device", ArgumentSemantic.Strong)]
        string Device { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull userId;
        [Export("userId", ArgumentSemantic.Strong)]
        string UserId { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull licensee;
        [Export("licensee", ArgumentSemantic.Strong)]
        string Licensee { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull applicationIds;
        [Export("applicationIds", ArgumentSemantic.Strong)]
        NSObject[] ApplicationIds { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull licenseId;
        [Export("licenseId", ArgumentSemantic.Strong)]
        string LicenseId { get; }
    }

    partial interface Constants
    {
        /*
        // extern const MBExceptionName MBIllegalModificationException;
        [Field("MBIllegalModificationException", "__Internal")]
        NSString MBIllegalModificationException { get; }
        
        // extern const MBExceptionName MBInvalidArgumentException;
        [Field("MBInvalidArgumentException", "__Internal")]
        NSString MBInvalidArgumentException { get; }

        // extern const MBExceptionName MBInvalidBundleException;
        [Field("MBInvalidBundleException", "__Internal")]
        NSString MBInvalidBundleException { get; }

        // extern const MBExceptionName MBInvalidLicenseKeyException;
        [Field("MBInvalidLicenseKeyException", "__Internal")]
        NSString MBInvalidLicenseKeyException { get; }

        // extern const MBExceptionName MBInvalidLicenseResourceException;
        [Field("MBInvalidLicenseResourceException", "__Internal")]
        NSString MBInvalidLicenseResourceException { get; }

        // extern const MBExceptionName MBInvalidLicenseeKeyException;
        [Field("MBInvalidLicenseeKeyException", "__Internal")]
        NSString MBInvalidLicenseeKeyException { get; }

        // extern const MBExceptionName MBMissingSettingsException;
        [Field("MBMissingSettingsException", "__Internal")]
        NSString MBMissingSettingsException { get; } }
        */
    }

    /*
    // @interface MBBgraImage : MBImage
    [BaseType(typeof(MBImage))]
    [DisableDefaultCtor]
    interface MBBgraImage
    {
    }
    */

    // @interface MBSignedPayload : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBSignedPayload
    {
        // @property (readonly, nonatomic) NSString * _Nullable payload;
        [NullAllowed, Export("payload")]
        string Payload { get; }

        // @property (readonly, nonatomic) NSString * _Nullable signature;
        [NullAllowed, Export("signature")]
        string Signature { get; }

        // @property (readonly, nonatomic) NSString * _Nullable signatureVersion;
        [NullAllowed, Export("signatureVersion")]
        string SignatureVersion { get; }

        // -(instancetype _Nonnull)initWithPayload:(NSString * _Nonnull)payload signature:(NSString * _Nonnull)signature signatureVersion:(NSString * _Nonnull)signatureVersion __attribute__((objc_designated_initializer));
        [Export("initWithPayload:signature:signatureVersion:")]
        [DesignatedInitializer]
        IntPtr Constructor(string payload, string signature, string signatureVersion);
    }

    // @protocol MBDebugRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBDebugRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugImage:(MBImage * _Nonnull)image;
        [Abstract]
        [Export("recognizerRunnerViewController:didOutputDebugImage:")]
        void DidOutputDebugImage(MBRecognizerRunnerViewController recognizerRunnerViewController, MBImage image);

        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugText:(NSString * _Nonnull)text;
        [Abstract]
        [Export("recognizerRunnerViewController:didOutputDebugText:")]
        void DidOutputDebugText(MBRecognizerRunnerViewController recognizerRunnerViewController, string text);
    }

    // @protocol MBDetectionRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBDetectionRecognizerRunnerViewControllerDelegate
    {
        // @optional -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayableQuad:(MBDisplayableQuadDetection * _Nonnull)displayableQuad;
        [Export("recognizerRunnerViewController:didFinishDetectionWithDisplayableQuad:")]
        void RecognizerRunnerViewController(MBRecognizerRunnerViewController recognizerRunnerViewController, MBDisplayableQuadDetection displayableQuad);

        // @optional -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayablePoints:(MBDisplayablePointsDetection * _Nonnull)displayablePoints;
        [Export("recognizerRunnerViewController:didFinishDetectionWithDisplayablePoints:")]
        void RecognizerRunnerViewController(MBRecognizerRunnerViewController recognizerRunnerViewController, MBDisplayablePointsDetection displayablePoints);

        // @optional -(void)recognizerRunnerViewControllerDidFailDetection:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Export("recognizerRunnerViewControllerDidFailDetection:")]
        void RecognizerRunnerViewControllerDidFailDetection(MBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBOcrLayout : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrLayout
    {
        // @property (nonatomic) CGRect box;
        [Export("box", ArgumentSemantic.Assign)]
        CGRect Box { get; set; }

        // @property (nonatomic) NSArray<MBOcrBlock *> * _Nonnull blocks;
        [Export("blocks", ArgumentSemantic.Assign)]
        MBOcrBlock[] Blocks { get; set; }

        // @property (nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }

        // @property (nonatomic) BOOL transformInvalid;
        [Export("transformInvalid")]
        bool TransformInvalid { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // @property (nonatomic) BOOL flipped;
        [Export("flipped")]
        bool Flipped { get; set; }

        // -(instancetype _Nonnull)initWithOcrBlocks:(NSArray<MBOcrBlock *> * _Nonnull)ocrBlocks transform:(CGAffineTransform)transform box:(CGRect)box flipped:(BOOL)flipped __attribute__((objc_designated_initializer));
        [Export("initWithOcrBlocks:transform:box:flipped:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrBlock[] ocrBlocks, CGAffineTransform transform, CGRect box, bool flipped);

        // -(instancetype _Nonnull)initWithOcrBlocks:(NSArray * _Nonnull)ocrBlocks;
        [Export("initWithOcrBlocks:")]
        IntPtr Constructor(NSObject[] ocrBlocks);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBOcrBlock : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrBlock
    {
        // @property (nonatomic) NSArray<MBOcrLine *> * _Nonnull lines;
        [Export("lines", ArgumentSemantic.Assign)]
        MBOcrLine[] Lines { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // -(instancetype _Nonnull)initWithOcrLines:(NSArray<MBOcrLine *> * _Nonnull)ocrLines position:(MBPosition * _Nonnull)position __attribute__((objc_designated_initializer));
        [Export("initWithOcrLines:position:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrLine[] ocrLines, MBPosition position);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBOcrLine : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrLine
    {
        // @property (nonatomic) NSArray<MBCharWithVariants *> * _Nonnull chars;
        [Export("chars", ArgumentSemantic.Assign)]
        MBCharWithVariants[] Chars { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // -(instancetype _Nonnull)initWithOcrChars:(NSArray<MBCharWithVariants *> * _Nonnull)ocrChars position:(MBPosition * _Nonnull)position __attribute__((objc_designated_initializer));
        [Export("initWithOcrChars:position:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBCharWithVariants[] ocrChars, MBPosition position);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBCharWithVariants : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBCharWithVariants
    {
        // @property (nonatomic) MBOcrChar * _Nonnull character;
        [Export("character", ArgumentSemantic.Assign)]
        MBOcrChar Character { get; set; }

        // @property (nonatomic) NSSet * _Nonnull variants;
        [Export("variants", ArgumentSemantic.Assign)]
        NSSet Variants { get; set; }

        // -(instancetype _Nonnull)initWithValue:(MBOcrChar * _Nonnull)character __attribute__((objc_designated_initializer));
        [Export("initWithValue:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrChar character);
    }

    // @interface MBOcrChar : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrChar
    {
        // @property (nonatomic) unichar value;
        [Export("value")]
        ushort Value { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // @property (nonatomic) CGFloat height;
        [Export("height")]
        nfloat Height { get; set; }

        // @property (getter = isUncertain, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { [Bind("isUncertain")] get; set; }

        // @property (nonatomic) NSInteger quality;
        [Export("quality")]
        nint Quality { get; set; }

        // @property (nonatomic) MBOcrFont font;
        [Export("font", ArgumentSemantic.Assign)]
        MBOcrFont Font { get; set; }

        // -(instancetype _Nonnull)initWithValue:(unichar)value position:(MBPosition * _Nonnull)position height:(CGFloat)height __attribute__((objc_designated_initializer));
        [Export("initWithValue:position:height:")]
        [DesignatedInitializer]
        IntPtr Constructor(ushort value, MBPosition position, nfloat height);
    }

    // @interface MBPosition : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBPosition
    {
        // @property (nonatomic) CGPoint ul;
        [Export("ul", ArgumentSemantic.Assign)]
        CGPoint Ul { get; set; }

        // @property (nonatomic) CGPoint ur;
        [Export("ur", ArgumentSemantic.Assign)]
        CGPoint Ur { get; set; }

        // @property (nonatomic) CGPoint ll;
        [Export("ll", ArgumentSemantic.Assign)]
        CGPoint Ll { get; set; }

        // @property (nonatomic) CGPoint lr;
        [Export("lr", ArgumentSemantic.Assign)]
        CGPoint Lr { get; set; }

        // -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)ul upperRight:(CGPoint)ur lowerLeft:(CGPoint)ll lowerRight:(CGPoint)lr __attribute__((objc_designated_initializer));
        [Export("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGPoint ul, CGPoint ur, CGPoint ll, CGPoint lr);

        // -(MBPosition * _Nonnull)positionWithOffset:(CGPoint)offset;
        [Export("positionWithOffset:")]
        MBPosition PositionWithOffset(CGPoint offset);

        // -(CGRect)rect;
        [Export("rect")]
        CGRect Rect { get; }

        // -(CGPoint)center;
        [Export("center")]
        CGPoint Center { get; }

        // -(CGFloat)height;
        [Export("height")]
        nfloat Height { get; }
    }

    // @protocol MBOcrRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBOcrRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didObtainOcrResult:(MBOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
        [Abstract]
        [Export("recognizerRunnerViewController:didObtainOcrResult:withResultName:")]
        void DidObtainOcrResult(MBRecognizerRunnerViewController recognizerRunnerViewController, MBOcrLayout ocrResult, string resultName);
    }

    // @protocol MBGlareRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBGlareRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishGlareDetectionWithResult:(BOOL)glareFound;
        [Abstract]
        [Export("recognizerRunnerViewController:didFinishGlareDetectionWithResult:")]
        void DidFinishGlareDetectionWithResult(MBRecognizerRunnerViewController recognizerRunnerViewController, bool glareFound);
    }

    // @protocol MBFirstSideFinishedRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBFirstSideFinishedRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:")]
        void RecognizerRunnerViewControllerDidFinishRecognitionOfFirstSide(MBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBRecognizerRunnerViewControllerMetadataDelegates : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewControllerMetadataDelegates
    {
        [Wrap("WeakDebugRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBDebugRecognizerRunnerViewControllerDelegate DebugRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDebugRecognizerRunnerViewControllerDelegate> _Nullable debugRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("debugRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakDetectionRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBDetectionRecognizerRunnerViewControllerDelegate DetectionRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDetectionRecognizerRunnerViewControllerDelegate> _Nullable detectionRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("detectionRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDetectionRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakOcrRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBOcrRecognizerRunnerViewControllerDelegate OcrRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBOcrRecognizerRunnerViewControllerDelegate> _Nullable ocrRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("ocrRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakOcrRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakGlareRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBGlareRecognizerRunnerViewControllerDelegate GlareRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBGlareRecognizerRunnerViewControllerDelegate> _Nullable glareRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("glareRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakGlareRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBFirstSideFinishedRecognizerRunnerViewControllerDelegate FirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBFirstSideFinishedRecognizerRunnerViewControllerDelegate> _Nullable firstSideFinishedRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("firstSideFinishedRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }
    }

    // @protocol MBRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerUnauthorizedCamera:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerUnauthorizedCamera:")]
        void RecognizerRunnerViewControllerUnauthorizedCamera(MBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFindError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("recognizerRunnerViewController:didFindError:")]
        void RecognizerRunnerViewController(MBRecognizerRunnerViewController recognizerRunnerViewController, NSError error);

        // @required -(void)recognizerRunnerViewControllerDidClose:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidClose:")]
        void RecognizerRunnerViewControllerDidClose(MBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerWillPresentHelp:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerWillPresentHelp:")]
        void RecognizerRunnerViewControllerWillPresentHelp(MBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerDidResumeScanning:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidResumeScanning:")]
        void RecognizerRunnerViewControllerDidResumeScanning(MBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerDidStopScanning:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidStopScanning:")]
        void RecognizerRunnerViewControllerDidStopScanning(MBRecognizerRunnerViewController recognizerRunnerViewController);

        // @optional -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController willSetTorch:(BOOL)isTorchOn;
        [Export("recognizerRunnerViewController:willSetTorch:")]
        void RecognizerRunnerViewController(MBRecognizerRunnerViewController recognizerRunnerViewController, bool isTorchOn);
    }

    // @protocol MBScanningRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBScanningRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerDidFinishScanning:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidFinishScanning:state:")]
        void State(MBRecognizerRunnerViewController recognizerRunnerViewController, MBRecognizerResultState state);
    }

    // @protocol MBFrameRecognitionRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBFrameRecognitionRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerDidFinishFrameRecognition:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidFinishFrameRecognition:state:")]
        void State(MBRecognizerRunnerViewController recognizerRunnerViewController, MBRecognizerResultState state);
    }

    // @protocol MBDebugRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBDebugRecognizerRunnerDelegate
    {
        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugImage:(MBImage * _Nonnull)image;
        [Export("recognizerRunner:didOutputDebugImage:")]
        void DidOutputDebugImage(MBRecognizerRunner recognizerRunner, MBImage image);

        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugText:(NSString * _Nonnull)text;
        [Export("recognizerRunner:didOutputDebugText:")]
        void DidOutputDebugText(MBRecognizerRunner recognizerRunner, string text);
    }

    // @protocol MBDetectionRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBDetectionRecognizerRunnerDelegate
    {
        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayableQuad:(MBDisplayableQuadDetection * _Nonnull)displayableQuad;
        [Export("recognizerRunner:didFinishDetectionWithDisplayableQuad:")]
        void RecognizerRunner(MBRecognizerRunner recognizerRunner, MBDisplayableQuadDetection displayableQuad);

        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayablePoints:(MBDisplayablePointsDetection * _Nonnull)displayablePoints;
        [Export("recognizerRunner:didFinishDetectionWithDisplayablePoints:")]
        void RecognizerRunner(MBRecognizerRunner recognizerRunner, MBDisplayablePointsDetection displayablePoints);

        // @optional -(void)recognizerRunnerDidFailDetection:(MBRecognizerRunner * _Nonnull)recognizerRunner;
        [Export("recognizerRunnerDidFailDetection:")]
        void RecognizerRunnerDidFailDetection(MBRecognizerRunner recognizerRunner);
    }

    // @protocol MBOcrRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBOcrRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didObtainOcrResult:(MBOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
        [Abstract]
        [Export("recognizerRunner:didObtainOcrResult:withResultName:")]
        void DidObtainOcrResult(MBRecognizerRunner recognizerRunner, MBOcrLayout ocrResult, string resultName);
    }

    // @protocol MBGlareRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBGlareRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishGlareDetectionWithResult:(BOOL)glareFound;
        [Abstract]
        [Export("recognizerRunner:didFinishGlareDetectionWithResult:")]
        void DidFinishGlareDetectionWithResult(MBRecognizerRunner recognizerRunner, bool glareFound);
    }

    // @protocol MBFirstSideFinishedRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBFirstSideFinishedRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunnerDidFinishRecognitionOfFirstSide:(MBRecognizerRunner * _Nonnull)recognizerRunner;
        [Abstract]
        [Export("recognizerRunnerDidFinishRecognitionOfFirstSide:")]
        void RecognizerRunnerDidFinishRecognitionOfFirstSide(MBRecognizerRunner recognizerRunner);
    }

    // @interface MBRecognizerRunnerMetadataDelegates : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerMetadataDelegates
    {
        [Wrap("WeakDebugRecognizerRunnerDelegate")]
        [NullAllowed]
        MBDebugRecognizerRunnerDelegate DebugRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDebugRecognizerRunnerDelegate> _Nullable debugRecognizerRunnerDelegate;
        [NullAllowed, Export("debugRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakDetectionRecognizerRunnerDelegate")]
        [NullAllowed]
        MBDetectionRecognizerRunnerDelegate DetectionRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDetectionRecognizerRunnerDelegate> _Nullable detectionRecognizerRunnerDelegate;
        [NullAllowed, Export("detectionRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDetectionRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakOcrRecognizerRunnerDelegate")]
        [NullAllowed]
        MBOcrRecognizerRunnerDelegate OcrRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBOcrRecognizerRunnerDelegate> _Nullable ocrRecognizerRunnerDelegate;
        [NullAllowed, Export("ocrRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakOcrRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakGlareRecognizerRunnerDelegate")]
        [NullAllowed]
        MBGlareRecognizerRunnerDelegate GlareRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBGlareRecognizerRunnerDelegate> _Nullable glareRecognizerRunnerDelegate;
        [NullAllowed, Export("glareRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakGlareRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakFirstSideFinishedRecognizerRunnerDelegate")]
        [NullAllowed]
        MBFirstSideFinishedRecognizerRunnerDelegate FirstSideFinishedRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBFirstSideFinishedRecognizerRunnerDelegate> _Nullable firstSideFinishedRecognizerRunnerDelegate;
        [NullAllowed, Export("firstSideFinishedRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakFirstSideFinishedRecognizerRunnerDelegate { get; set; }
    }

    // @protocol MBScanningRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBScanningRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishScanningWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("recognizerRunner:didFinishScanningWithState:")]
        void DidFinishScanningWithState(MBRecognizerRunner recognizerRunner, MBRecognizerResultState state);
    }

    // @protocol MBImageProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBImageProcessingRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingImage:(MBImage * _Nonnull)image;
        [Abstract]
        [Export("recognizerRunner:didFinishProcessingImage:")]
        void DidFinishProcessingImage(MBRecognizerRunner recognizerRunner, MBImage image);
    }

    // @protocol MBStringProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBStringProcessingRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingString:(NSString * _Nonnull)string;
        [Abstract]
        [Export("recognizerRunner:didFinishProcessingString:")]
        void DidFinishProcessingString(MBRecognizerRunner recognizerRunner, string @string);
    }

    // @interface MBRecognizerRunner : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerRunner
    {
        // @property (readonly, nonatomic, strong) MBRecognizerRunnerMetadataDelegates * _Nonnull metadataDelegates;
        [Export("metadataDelegates", ArgumentSemantic.Strong)]
        MBRecognizerRunnerMetadataDelegates MetadataDelegates { get; }

        [Wrap("WeakScanningRecognizerRunnerDelegate")]
        [NullAllowed]
        MBScanningRecognizerRunnerDelegate ScanningRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBScanningRecognizerRunnerDelegate> _Nullable scanningRecognizerRunnerDelegate;
        [NullAllowed, Export("scanningRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakScanningRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakImageProcessingRecognizerRunnerDelegate")]
        [NullAllowed]
        MBImageProcessingRecognizerRunnerDelegate ImageProcessingRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBImageProcessingRecognizerRunnerDelegate> _Nullable imageProcessingRecognizerRunnerDelegate;
        [NullAllowed, Export("imageProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakImageProcessingRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakStringProcessingRecognizerRunnerDelegate")]
        [NullAllowed]
        MBStringProcessingRecognizerRunnerDelegate StringProcessingRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBStringProcessingRecognizerRunnerDelegate> _Nullable stringProcessingRecognizerRunnerDelegate;
        [NullAllowed, Export("stringProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakStringProcessingRecognizerRunnerDelegate { get; set; }

        // -(instancetype _Nonnull)initWithRecognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection __attribute__((objc_designated_initializer));
        [Export("initWithRecognizerCollection:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizerCollection recognizerCollection);

        // -(void)resetState;
        [Export("resetState")]
        void ResetState();

        // -(void)resetState:(BOOL)hard;
        [Export("resetState:")]
        void ResetState(bool hard);

        // -(void)cancelProcessing;
        [Export("cancelProcessing")]
        void CancelProcessing();

        // -(void)processImage:(MBImage * _Nonnull)image;
        [Export("processImage:")]
        void ProcessImage(MBImage image);

        // -(void)processString:(NSString * _Nonnull)string;
        [Export("processString:")]
        void ProcessString(string @string);

        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBEntity : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBEntity
    {
    }

    // @interface MBRecognizer : MBEntity
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBEntity))]
    interface MBRecognizer
    {
        // @property (readonly, nonatomic, weak) MBRecognizerResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBRecognizerResult BaseResult { get; }

        // -(UIInterfaceOrientationMask)getOptimalHudOrientation;
        [Export("getOptimalHudOrientation")]
        UIInterfaceOrientationMask OptimalHudOrientation { get; }

        // -(MBSignedPayload * _Nonnull)toSignedJson;
        [Export("toSignedJson")]
        MBSignedPayload ToSignedJson { get; }
    }

    // @interface MBFrameGrabberRecognizer : MBRecognizer <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBFrameGrabberRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithFrameGrabberDelegate:(id<MBFrameGrabberRecognizerDelegate> _Nonnull)frameGrabberDelegate __attribute__((swift_name("init(frameGrabberDelegate:)")));
        [Export("initWithFrameGrabberDelegate:")]
        IntPtr Constructor(MBFrameGrabberRecognizerDelegate frameGrabberDelegate);

        // @property (assign, nonatomic) BOOL grabFocusedFrames;
        [Export("grabFocusedFrames")]
        bool GrabFocusedFrames { get; set; }

        // @property (assign, nonatomic) BOOL grabUnfocusedFrames;
        [Export("grabUnfocusedFrames")]
        bool GrabUnfocusedFrames { get; set; }
    }

    // @protocol MBFrameGrabberRecognizerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBFrameGrabberRecognizerDelegate
    {
        // @required -(void)onFrameAvailable:(MBImage * _Nonnull)cameraFrame isFocused:(BOOL)focused frameQuality:(CGFloat)frameQuality;
        [Abstract]
        [Export("onFrameAvailable:isFocused:frameQuality:")]
        void IsFocused(MBImage cameraFrame, bool focused, nfloat frameQuality);
    }

    // @interface MBSuccessFrameGrabberRecognizerResult : MBRecognizerResult <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSuccessFrameGrabberRecognizerResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBImage * _Nonnull successFrame;
        [Export("successFrame", ArgumentSemantic.Strong)]
        MBImage SuccessFrame { get; }
    }

    // @interface MBSuccessFrameGrabberRecognizer : MBRecognizer <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBSuccessFrameGrabberRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithRecognizer:(MBRecognizer * _Nonnull)recognizer __attribute__((swift_name("init(recognizer:)"))) __attribute__((objc_designated_initializer));
        [Export("initWithRecognizer:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizer recognizer);

        // @property (readonly, nonatomic, strong) MBSuccessFrameGrabberRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSuccessFrameGrabberRecognizerResult Result { get; }

        // @property (readonly, nonatomic, strong) MBRecognizer * _Nonnull slaveRecognizer;
        [Export("slaveRecognizer", ArgumentSemantic.Strong)]
        MBRecognizer SlaveRecognizer { get; }
    }

    // @protocol MBFullDocumentImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentImage")]
        MBImage FullDocumentImage { get; }
    }

    // @interface MBQuadrangle : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBQuadrangle
    {
        // @property (assign, nonatomic) CGPoint upperLeft;
        [Export("upperLeft", ArgumentSemantic.Assign)]
        CGPoint UpperLeft { get; set; }

        // @property (assign, nonatomic) CGPoint upperRight;
        [Export("upperRight", ArgumentSemantic.Assign)]
        CGPoint UpperRight { get; set; }

        // @property (assign, nonatomic) CGPoint lowerLeft;
        [Export("lowerLeft", ArgumentSemantic.Assign)]
        CGPoint LowerLeft { get; set; }

        // @property (assign, nonatomic) CGPoint lowerRight;
        [Export("lowerRight", ArgumentSemantic.Assign)]
        CGPoint LowerRight { get; set; }

        // -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)upperLeft upperRight:(CGPoint)upperRight lowerLeft:(CGPoint)lowerLeft lowerRight:(CGPoint)lowerRight;
        [Export("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
        IntPtr Constructor(CGPoint upperLeft, CGPoint upperRight, CGPoint lowerLeft, CGPoint lowerRight);

        // -(NSArray * _Nonnull)toPointsArray;
        [Export("toPointsArray")]
        NSObject[] ToPointsArray { get; }

        // -(instancetype _Nonnull)quadrangleWithTransformation:(CGAffineTransform)transform;
        [Export("quadrangleWithTransformation:")]
        MBQuadrangle QuadrangleWithTransformation(CGAffineTransform transform);

        // -(CGPoint)center;
        [Export("center")]
        CGPoint Center { get; }
    }

    // @interface MBDocumentFaceRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBFaceImageResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBDocumentFaceRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBFaceImageResult
    {
        // @property (readonly, nonatomic) MBQuadrangle * _Nonnull documentLocation;
        [Export("documentLocation")]
        MBQuadrangle DocumentLocation { get; }

        // @property (readonly, nonatomic) MBQuadrangle * _Nonnull faceLocation;
        [Export("faceLocation")]
        MBQuadrangle FaceLocation { get; }
    }

    // @protocol MBFullDocumentImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL returnFullDocumentImage;
        [Abstract]
        [Export("returnFullDocumentImage")]
        bool ReturnFullDocumentImage { get; set; }
    }

    // @protocol MBFullDocumentImageDpi
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBFullDocumentImageDpi
    {
        // @required @property (assign, nonatomic) NSInteger fullDocumentImageDpi;
        [Abstract]
        [Export("fullDocumentImageDpi")]
        nint FullDocumentImageDpi { get; set; }
    }

    // @protocol MBFaceImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBFaceImage
    {
        // @required @property (assign, nonatomic) BOOL returnFaceImage;
        [Abstract]
        [Export("returnFaceImage")]
        bool ReturnFaceImage { get; set; }
    }

    // @protocol MBFaceImageDpi
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBFaceImageDpi
    {
        // @required @property (assign, nonatomic) NSInteger faceImageDpi;
        [Abstract]
        [Export("faceImageDpi")]
        nint FaceImageDpi { get; set; }
    }

    // @protocol MBFullDocumentImageExtensionFactors
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBFullDocumentImageExtensionFactors
    {
        // @required @property (assign, nonatomic) MBImageExtensionFactors fullDocumentImageExtensionFactors;
        [Abstract]
        [Export("fullDocumentImageExtensionFactors", ArgumentSemantic.Assign)]
        MBImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
    }

    // @interface MBDocumentFaceRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBFaceImageDpi, MBFullDocumentImageExtensionFactors>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBDocumentFaceRecognizer : INSCopying, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBDocumentFaceRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBDocumentFaceRecognizerResult Result { get; }

        // @property (assign, nonatomic) MBDocumentFaceDetectorType detectorType;
        [Export("detectorType", ArgumentSemantic.Assign)]
        MBDocumentFaceDetectorType DetectorType { get; set; }

        // @property (assign, nonatomic) NSInteger numStableDetectionsThreshold;
        [Export("numStableDetectionsThreshold")]
        nint NumStableDetectionsThreshold { get; set; }
    }

    // @protocol MBEncodedFullDocumentImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBEncodedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentImage")]
        NSData EncodedFullDocumentImage { get; }
    }

    // @interface MBBlinkIdSingleSideRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBFaceImageResult, MBEncodedFaceImageResult, MBAgeResult, MBDocumentExpirationCheckResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBlinkIdSingleSideRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBAgeResult, IMBDocumentExpirationCheckResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBStringResult * _Nullable address;
        [NullAllowed, Export("address")]
        MBStringResult Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) BOOL dateOfExpiryPermanent;
        [Export("dateOfExpiryPermanent")]
        bool DateOfExpiryPermanent { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        MBStringResult DocumentNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        MBStringResult FirstName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable fullName;
        [NullAllowed, Export("fullName")]
        MBStringResult FullName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        MBStringResult LastName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable fathersName;
        [NullAllowed, Export("fathersName")]
        MBStringResult FathersName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable mothersName;
        [NullAllowed, Export("mothersName")]
        MBStringResult MothersName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable sex;
        [NullAllowed, Export("sex")]
        MBStringResult Sex { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable localizedName;
        [NullAllowed, Export("localizedName")]
        MBStringResult LocalizedName { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalNameInformation;
        [NullAllowed, Export("additionalNameInformation")]
        MBStringResult AdditionalNameInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalAddressInformation;
        [NullAllowed, Export("additionalAddressInformation")]
        MBStringResult AdditionalAddressInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable additionalOptionalAddressInformation;
        [NullAllowed, Export("additionalOptionalAddressInformation")]
        MBStringResult AdditionalOptionalAddressInformation { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        MBStringResult PlaceOfBirth { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        MBStringResult Nationality { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable race;
        [NullAllowed, Export("race")]
        MBStringResult Race { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable religion;
        [NullAllowed, Export("religion")]
        MBStringResult Religion { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable profession;
        [NullAllowed, Export("profession")]
        MBStringResult Profession { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable maritalStatus;
        [NullAllowed, Export("maritalStatus")]
        MBStringResult MaritalStatus { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable residentialStatus;
        [NullAllowed, Export("residentialStatus")]
        MBStringResult ResidentialStatus { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable employer;
        [NullAllowed, Export("employer")]
        MBStringResult Employer { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable personalIdNumber;
        [NullAllowed, Export("personalIdNumber")]
        MBStringResult PersonalIdNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentAdditionalNumber;
        [NullAllowed, Export("documentAdditionalNumber")]
        MBStringResult DocumentAdditionalNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentOptionalAdditionalNumber;
        [NullAllowed, Export("documentOptionalAdditionalNumber")]
        MBStringResult DocumentOptionalAdditionalNumber { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        MBStringResult IssuingAuthority { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable documentSubtype;
        [NullAllowed, Export("documentSubtype")]
        MBStringResult DocumentSubtype { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable sponsor;
        [NullAllowed, Export("sponsor")]
        MBStringResult Sponsor { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable bloodType;
        [NullAllowed, Export("bloodType")]
        MBStringResult BloodType { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
        [NullAllowed, Export("driverLicenseDetailedInfo")]
        MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

        // @property (readonly, nonatomic) MBClassInfo * _Nullable classInfo;
        [NullAllowed, Export("classInfo")]
        MBClassInfo ClassInfo { get; }

        // @property (readonly, nonatomic) MBImageAnalysisResult * _Nullable imageAnalysisResult;
        [NullAllowed, Export("imageAnalysisResult")]
        MBImageAnalysisResult ImageAnalysisResult { get; }

        // @property (readonly, nonatomic) MBBarcodeResult * _Nullable barcodeResult;
        [NullAllowed, Export("barcodeResult")]
        MBBarcodeResult BarcodeResult { get; }

        // @property (readonly, nonatomic) MBVizResult * _Nullable vizResult;
        [NullAllowed, Export("vizResult")]
        MBVizResult VizResult { get; }

        // @property (readonly, assign, nonatomic) MBProcessingStatus processingStatus;
        [Export("processingStatus", ArgumentSemantic.Assign)]
        MBProcessingStatus ProcessingStatus { get; }

        // @property (readonly, nonatomic) MBAdditionalProcessingInfo * _Nullable additionalProcessingInfo;
        [NullAllowed, Export("additionalProcessingInfo")]
        MBAdditionalProcessingInfo AdditionalProcessingInfo { get; }

        // @property (readonly, assign, nonatomic) MBRecognitionMode recognitionMode;
        [Export("recognitionMode", ArgumentSemantic.Assign)]
        MBRecognitionMode RecognitionMode { get; }

        // @property (readonly, nonatomic) MBImage * _Nullable cameraFrame;
        [NullAllowed, Export("cameraFrame")]
        MBImage CameraFrame { get; }

        // @property (readonly, nonatomic) MBImage * _Nullable barcodeCameraFrame;
        [NullAllowed, Export("barcodeCameraFrame")]
        MBImage BarcodeCameraFrame { get; }

        // @property (readonly, nonatomic) CGRect faceImageLocation;
        [Export("faceImageLocation")]
        CGRect FaceImageLocation { get; }

        // @property (readonly, nonatomic) MBSide faceImageSide;
        [Export("faceImageSide")]
        MBSide FaceImageSide { get; }
    }

    // @protocol MBEncodeFaceImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBEncodeFaceImage
    {
        // @required @property (assign, nonatomic) BOOL encodeFaceImage;
        [Abstract]
        [Export("encodeFaceImage")]
        bool EncodeFaceImage { get; set; }
    }

    // @protocol MBEncodeFullDocumentImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBEncodeFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL encodeFullDocumentImage;
        [Abstract]
        [Export("encodeFullDocumentImage")]
        bool EncodeFullDocumentImage { get; set; }
    }

    // @interface MBRecognitionModeFilter : NSObject <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBRecognitionModeFilter : INSCopying
    {
        // @property (assign, nonatomic) BOOL enableMrzId;
        [Export("enableMrzId")]
        bool EnableMrzId { get; set; }

        // @property (assign, nonatomic) BOOL enableMrzVisa;
        [Export("enableMrzVisa")]
        bool EnableMrzVisa { get; set; }

        // @property (assign, nonatomic) BOOL enableMrzPassport;
        [Export("enableMrzPassport")]
        bool EnableMrzPassport { get; set; }

        // @property (assign, nonatomic) BOOL enablePhotoId;
        [Export("enablePhotoId")]
        bool EnablePhotoId { get; set; }

        // @property (assign, nonatomic) BOOL enableBarcodeId;
        [Export("enableBarcodeId")]
        bool EnableBarcodeId { get; set; }

        // @property (assign, nonatomic) BOOL enableFullDocumentRecognition;
        [Export("enableFullDocumentRecognition")]
        bool EnableFullDocumentRecognition { get; set; }
    }

    // @protocol MBSignatureImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBSignatureImage
    {
        // @required @property (assign, nonatomic) BOOL returnSignatureImage;
        [Abstract]
        [Export("returnSignatureImage")]
        bool ReturnSignatureImage { get; set; }
    }

    // @protocol MBSignatureImageDpi
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBSignatureImageDpi
    {
        // @required @property (assign, nonatomic) NSInteger signatureImageDpi;
        [Abstract]
        [Export("signatureImageDpi")]
        nint SignatureImageDpi { get; set; }
    }

    // @protocol MBEncodeSignatureImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBEncodeSignatureImage
    {
        // @required @property (assign, nonatomic) BOOL encodeSignatureImage;
        [Abstract]
        [Export("encodeSignatureImage")]
        bool EncodeSignatureImage { get; set; }
    }

    // @protocol MBCameraFrames
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBCameraFrames
    {
        // @required @property (assign, nonatomic) BOOL saveCameraFrames;
        [Abstract]
        [Export("saveCameraFrames")]
        bool SaveCameraFrames { get; set; }
    }

    // @interface MBDocumentNumberAnonymizationSettings : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBDocumentNumberAnonymizationSettings
    {
        // @property (nonatomic) NSInteger prefixDigitsVisible;
        [Export("prefixDigitsVisible")]
        nint PrefixDigitsVisible { get; set; }

        // @property (nonatomic) NSInteger suffixDigitsVisible;
        [Export("suffixDigitsVisible")]
        nint SuffixDigitsVisible { get; set; }

        // -(instancetype _Nonnull)initWithPrefixDigitsVisible:(NSInteger)prefixDigitsVisible suffixDigitsVisible:(NSInteger)suffixDigitsVisible;
        [Export("initWithPrefixDigitsVisible:suffixDigitsVisible:")]
        IntPtr Constructor(nint prefixDigitsVisible, nint suffixDigitsVisible);
    }

    // @interface MBClassAnonymizationSettings : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBClassAnonymizationSettings
    {
        // @property (assign, nonatomic) NSNumber * _Nonnull country;
        [Export("country", ArgumentSemantic.Assign)]
        NSNumber Country { get; set; }

        // @property (assign, nonatomic) NSNumber * _Nonnull region;
        [Export("region", ArgumentSemantic.Assign)]
        NSNumber Region { get; set; }

        // @property (assign, nonatomic) NSNumber * _Nonnull type;
        [Export("type", ArgumentSemantic.Assign)]
        NSNumber Type { get; set; }

        // @property (nonatomic, strong) NSArray<NSNumber *> * _Nonnull fields;
        [Export("fields", ArgumentSemantic.Strong)]
        NSNumber[] Fields { get; set; }

        // @property (nonatomic, strong) MBDocumentNumberAnonymizationSettings * _Nonnull documentNumberAnonymizationSettings;
        [Export("documentNumberAnonymizationSettings", ArgumentSemantic.Strong)]
        MBDocumentNumberAnonymizationSettings DocumentNumberAnonymizationSettings { get; set; }

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country region:(MBRegion)region type:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithCountry:region:type:fields:")]
        IntPtr Constructor(MBCountry country, MBRegion region, MBType type, NSNumber[] fields);

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country region:(MBRegion)region fields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithCountry:region:fields:")]
        IntPtr Constructor(MBCountry country, MBRegion region, NSNumber[] fields);

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country type:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithCountry:type:fields:")]
        IntPtr Constructor(MBCountry country, MBType type, NSNumber[] fields);

        // -(instancetype _Nonnull)initWithRegion:(MBRegion)region type:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithRegion:type:fields:")]
        IntPtr Constructor(MBRegion region, MBType type, NSNumber[] fields);

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country fields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithCountry:fields:")]
        IntPtr Constructor(MBCountry country, NSNumber[] fields);

        // -(instancetype _Nonnull)initWithRegion:(MBRegion)region fields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithRegion:fields:")]
        IntPtr Constructor(MBRegion region, NSNumber[] fields);

        // -(instancetype _Nonnull)initWithType:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithType:fields:")]
        IntPtr Constructor(MBType type, NSNumber[] fields);

        // -(instancetype _Nonnull)initWithFields:(NSArray<NSNumber *> * _Nonnull)fields;
        [Export("initWithFields:")]
        IntPtr Constructor(NSNumber[] fields);

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country region:(MBRegion)region type:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithCountry:region:type:fields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(MBCountry country, MBRegion region, MBType type, NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country region:(MBRegion)region fields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithCountry:region:fields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(MBCountry country, MBRegion region, NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country type:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithCountry:type:fields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(MBCountry country, MBType type, NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);

        // -(instancetype _Nonnull)initWithRegion:(MBRegion)region type:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithRegion:type:fields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(MBRegion region, MBType type, NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);

        // -(instancetype _Nonnull)initWithCountry:(MBCountry)country fields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithCountry:fields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(MBCountry country, NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);

        // -(instancetype _Nonnull)initWithRegion:(MBRegion)region fields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithRegion:fields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(MBRegion region, NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);

        // -(instancetype _Nonnull)initWithType:(MBType)type fields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithType:fields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(MBType type, NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);

        // -(instancetype _Nonnull)initWithFields:(NSArray<NSNumber *> * _Nonnull)fields documentNumberAnonymizationSettings:(MBDocumentNumberAnonymizationSettings * _Nonnull)documentNumberAnonymizationSettings;
        [Export("initWithFields:documentNumberAnonymizationSettings:")]
        IntPtr Constructor(NSNumber[] fields, MBDocumentNumberAnonymizationSettings documentNumberAnonymizationSettings);
    }

    // @protocol MBClassAnonymization
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBClassAnonymization
    {
        // @required @property (readonly, nonatomic) NSArray<MBClassAnonymizationSettings *> * recognizerAdditionalAnonymizationSettings;
        [Abstract]
        [Export("recognizerAdditionalAnonymizationSettings")]
        MBClassAnonymizationSettings[] RecognizerAdditionalAnonymizationSettings { get; }

        // @required -(void)recognizerAddClassToAdditionalAnonymization:(MBClassAnonymizationSettings *)additionalAnonymizationClass __attribute__((swift_name("recognizerAddClassToAdditionalAnonymization(_:)")));
        [Abstract]
        [Export("recognizerAddClassToAdditionalAnonymization:")]
        void RecognizerAddClassToAdditionalAnonymization(MBClassAnonymizationSettings additionalAnonymizationClass);

        // @required -(void)recognizerRemoveClassFromAdditionalAnonymization:(MBClassAnonymizationSettings *)additionalAnonymizationClass __attribute__((swift_name("recognizerRemoveClassFromAdditionalAnonymization(_:)")));
        [Abstract]
        [Export("recognizerRemoveClassFromAdditionalAnonymization:")]
        void RecognizerRemoveClassFromAdditionalAnonymization(MBClassAnonymizationSettings additionalAnonymizationClass);

        // @required -(void)recognizerRemoveAllClassesFromAdditionalAnonymization;
        [Abstract]
        [Export("recognizerRemoveAllClassesFromAdditionalAnonymization")]
        void RecognizerRemoveAllClassesFromAdditionalAnonymization();
    }

    // @interface MBBlinkIdSingleSideRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage, MBCameraFrames, MBClassAnonymization>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBBlinkIdSingleSideRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage, IMBCameraFrames, IMBClassAnonymization
    {
        // @property (readonly, nonatomic, strong) MBBlinkIdSingleSideRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBBlinkIdSingleSideRecognizerResult Result { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBBlinkIdSingleSideRecognizerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBBlinkIdSingleSideRecognizerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) BOOL enableBlurFilter;
        [Export("enableBlurFilter")]
        bool EnableBlurFilter { get; set; }

        // @property (assign, nonatomic) MBStrictnessLevel blurStrictnessLevel;
        [Export("blurStrictnessLevel", ArgumentSemantic.Assign)]
        MBStrictnessLevel BlurStrictnessLevel { get; set; }

        // @property (assign, nonatomic) BOOL enableGlareFilter;
        [Export("enableGlareFilter")]
        bool EnableGlareFilter { get; set; }

        // @property (assign, nonatomic) MBStrictnessLevel glareStrictnessLevel;
        [Export("glareStrictnessLevel", ArgumentSemantic.Assign)]
        MBStrictnessLevel GlareStrictnessLevel { get; set; }

        // @property (assign, nonatomic) BOOL allowUnparsedMrzResults;
        [Export("allowUnparsedMrzResults")]
        bool AllowUnparsedMrzResults { get; set; }

        // @property (assign, nonatomic) BOOL allowUnverifiedMrzResults;
        [Export("allowUnverifiedMrzResults")]
        bool AllowUnverifiedMrzResults { get; set; }

        // @property (assign, nonatomic) CGFloat paddingEdge;
        [Export("paddingEdge")]
        nfloat PaddingEdge { get; set; }

        // @property (assign, nonatomic) BOOL validateResultCharacters;
        [Export("validateResultCharacters")]
        bool ValidateResultCharacters { get; set; }

        // @property (assign, nonatomic) MBAnonymizationMode anonymizationMode;
        [Export("anonymizationMode", ArgumentSemantic.Assign)]
        MBAnonymizationMode AnonymizationMode { get; set; }

        // @property (nonatomic, strong) MBRecognitionModeFilter * _Nonnull recognitionModeFilter;
        [Export("recognitionModeFilter", ArgumentSemantic.Strong)]
        MBRecognitionModeFilter RecognitionModeFilter { get; set; }

        // @property (assign, nonatomic) BOOL scanCroppedDocumentImage;
        [Export("scanCroppedDocumentImage")]
        bool ScanCroppedDocumentImage { get; set; }
    }

    public interface IMBBlinkIdSingleSideRecognizerDelegate { }

    // @protocol MBBlinkIdSingleSideRecognizerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBBlinkIdSingleSideRecognizerDelegate
    {
        // @required -(void)onImageAvailable:(MBImage * _Nullable)dewarpedImage;
        [Abstract]
        [Export("onImageAvailable:")]
        void OnImageAvailable([NullAllowed] MBImage dewarpedImage);

        // @required -(void)onDocumentSupportStatus:(BOOL)isDocumentSupported;
        [Abstract]
        [Export("onDocumentSupportStatus:")]
        void OnDocumentSupportStatus(bool isDocumentSupported);

        // @required -(BOOL)classInfoFilter:(MBClassInfo * _Nullable)classInfo;
        [Abstract]
        [Export("classInfoFilter:")]
        bool ClassInfoFilter([NullAllowed] MBClassInfo classInfo);

        // @required -(void)onBarcodeScanningStarted;
        [Abstract]
        [Export("onBarcodeScanningStarted")]
        void OnBarcodeScanningStarted();
    }

    // @protocol MBCombinedRecognizer
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBCombinedRecognizer
    {
        // @required @property (readonly, nonatomic) MBRecognizerResult<MBCombinedRecognizerResult> * combinedResult;
        [Abstract]
        [Export("combinedResult")]
        IMBCombinedRecognizerResult CombinedResult { get; }
    }

    // @interface MBBlinkIdMultiSideRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage, MBCameraFrames, MBClassAnonymization>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBBlinkIdMultiSideRecognizer : INSCopying, IMBCombinedRecognizer, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage, IMBCameraFrames, IMBClassAnonymization
    {
        // @property (readonly, nonatomic, strong) MBBlinkIdMultiSideRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBBlinkIdMultiSideRecognizerResult Result { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBBlinkIdMultiSideRecognizerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBBlinkIdMultiSideRecognizerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) BOOL enableBlurFilter;
        [Export("enableBlurFilter")]
        bool EnableBlurFilter { get; set; }

        // @property (assign, nonatomic) MBStrictnessLevel blurStrictnessLevel;
        [Export("blurStrictnessLevel", ArgumentSemantic.Assign)]
        MBStrictnessLevel BlurStrictnessLevel { get; set; }

        // @property (assign, nonatomic) BOOL enableGlareFilter;
        [Export("enableGlareFilter")]
        bool EnableGlareFilter { get; set; }

        // @property (assign, nonatomic) MBStrictnessLevel glareStrictnessLevel;
        [Export("glareStrictnessLevel", ArgumentSemantic.Assign)]
        MBStrictnessLevel GlareStrictnessLevel { get; set; }

        // @property (assign, nonatomic) BOOL allowUnparsedMrzResults;
        [Export("allowUnparsedMrzResults")]
        bool AllowUnparsedMrzResults { get; set; }

        // @property (assign, nonatomic) BOOL allowUnverifiedMrzResults;
        [Export("allowUnverifiedMrzResults")]
        bool AllowUnverifiedMrzResults { get; set; }

        // @property (assign, nonatomic) CGFloat paddingEdge;
        [Export("paddingEdge")]
        nfloat PaddingEdge { get; set; }

        // @property (assign, nonatomic) BOOL skipUnsupportedBack;
        [Export("skipUnsupportedBack")]
        bool SkipUnsupportedBack { get; set; }

        // @property (assign, nonatomic) BOOL validateResultCharacters;
        [Export("validateResultCharacters")]
        bool ValidateResultCharacters { get; set; }

        // @property (assign, nonatomic) MBAnonymizationMode anonymizationMode;
        [Export("anonymizationMode", ArgumentSemantic.Assign)]
        MBAnonymizationMode AnonymizationMode { get; set; }

        // @property (nonatomic, strong) MBRecognitionModeFilter * _Nonnull recognitionModeFilter;
        [Export("recognitionModeFilter", ArgumentSemantic.Strong)]
        MBRecognitionModeFilter RecognitionModeFilter { get; set; }

        // @property (assign, nonatomic) BOOL scanCroppedDocumentImage;
        [Export("scanCroppedDocumentImage")]
        bool ScanCroppedDocumentImage { get; set; }

        // @property (assign, nonatomic) BOOL allowUncertainFrontSideScan;
        [Export("allowUncertainFrontSideScan")]
        bool AllowUncertainFrontSideScan { get; set; }

        // @property (assign, nonatomic) NSInteger maxAllowedMismatchesPerField;
        [Export("maxAllowedMismatchesPerField")]
        nint MaxAllowedMismatchesPerField { get; set; }
    }

    public interface IMBBlinkIdMultiSideRecognizerDelegate { }

    // @protocol MBBlinkIdMultiSideRecognizerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBBlinkIdMultiSideRecognizerDelegate
    {
        // @required -(void)onMultiSideImageAvailable:(MBImage * _Nullable)dewarpedImage;
        [Abstract]
        [Export("onMultiSideImageAvailable:")]
        void OnMultiSideImageAvailable([NullAllowed] MBImage dewarpedImage);

        // @required -(void)onMultiSideDocumentSupportStatus:(BOOL)isDocumentSupported;
        [Abstract]
        [Export("onMultiSideDocumentSupportStatus:")]
        void OnMultiSideDocumentSupportStatus(bool isDocumentSupported);

        // @required -(BOOL)multiSideClassInfoFilter:(MBClassInfo * _Nullable)classInfo;
        [Abstract]
        [Export("multiSideClassInfoFilter:")]
        bool MultiSideClassInfoFilter([NullAllowed] MBClassInfo classInfo);

        // @required -(void)onMultiSideBarcodeScanningStarted;
        [Abstract]
        [Export("onMultiSideBarcodeScanningStarted")]
        void OnMultiSideBarcodeScanningStarted();
    }

    // @interface MBIdBarcodeRecognizerResult : MBRecognizerResult <NSCopying, MBAgeResult, MBDocumentExpirationCheckResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBIdBarcodeRecognizerResult : INSCopying, IMBAgeResult, IMBDocumentExpirationCheckResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull additionalNameInformation;
        [Export("additionalNameInformation")]
        string AdditionalNameInformation { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDate * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDate DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDate * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDate * _Nonnull dateOfIssue;
        [Export("dateOfIssue")]
        MBDate DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentAdditionalNumber;
        [Export("documentAdditionalNumber")]
        string DocumentAdditionalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull employer;
        [Export("employer")]
        string Employer { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull middleName;
        [Export("middleName")]
        string MiddleName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
        [Export("maritalStatus")]
        string MaritalStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull personalIdNumber;
        [Export("personalIdNumber")]
        string PersonalIdNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull profession;
        [Export("profession")]
        string Profession { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull race;
        [Export("race")]
        string Race { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull residentialStatus;
        [Export("residentialStatus")]
        string ResidentialStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
        [NullAllowed, Export("rawData", ArgumentSemantic.Strong)]
        NSData RawData { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
        [NullAllowed, Export("stringData", ArgumentSemantic.Strong)]
        string StringData { get; }

        // @property (readonly, assign, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { get; }

        // @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
        [Export("barcodeType", ArgumentSemantic.Assign)]
        MBBarcodeType BarcodeType { get; }

        // @property (readonly, assign, nonatomic) MBIdBarcodeDocumentType documentType;
        [Export("documentType", ArgumentSemantic.Assign)]
        MBIdBarcodeDocumentType DocumentType { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull restrictions;
        [Export("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull endorsements;
        [Export("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull vehicleClass;
        [Export("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull postalCode;
        [Export("postalCode")]
        string PostalCode { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull jurisdiction;
        [Export("jurisdiction")]
        string Jurisdiction { get; }

        // @property (readonly, nonatomic) MBBarcodeElements * _Nonnull extendedElements;
        [Export("extendedElements")]
        MBBarcodeElements ExtendedElements { get; }
    }

    // @interface MBIdBarcodeRecognizer : MBRecognizer <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBIdBarcodeRecognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBIdBarcodeRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBIdBarcodeRecognizerResult Result { get; }
    }

    // @interface MBTemplatingRecognizerResult : MBRecognizerResult
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBTemplatingRecognizerResult
    {
        // @property (readonly, nonatomic, strong) MBTemplatingClass * _Nullable templatingClass;
        [NullAllowed, Export("templatingClass", ArgumentSemantic.Strong)]
        MBTemplatingClass TemplatingClass { get; }
    }

    // @interface MBTemplatingRecognizer : MBRecognizer
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBTemplatingRecognizer
    {
        // @property (readonly, nonatomic, strong) MBTemplatingRecognizerResult * _Nonnull templatingResult;
        [Export("templatingResult", ArgumentSemantic.Strong)]
        MBTemplatingRecognizerResult TemplatingResult { get; }

        // @property (assign, nonatomic) BOOL useGlareDetector;
        [Export("useGlareDetector")]
        bool UseGlareDetector { get; set; }

        // @property (readonly, nonatomic, strong) NSArray<__kindof MBTemplatingClass *> * _Nullable templatingClasses;
        [NullAllowed, Export("templatingClasses", ArgumentSemantic.Strong)]
        MBTemplatingClass[] TemplatingClasses { get; }

        // -(void)setTemplatingClasses:(NSArray<__kindof MBTemplatingClass *> * _Nullable)templatingClasses;
        [Export("setTemplatingClasses:")]
        void SetTemplatingClasses([NullAllowed] MBTemplatingClass[] templatingClasses);
    }

    // @protocol MBMrzImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface MBMrzImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable mrzImage;
        [Abstract]
        [NullAllowed, Export("mrzImage")]
        MBImage MrzImage { get; }
    }

    // @protocol MBEncodedMrzImageResult
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface MBEncodedMrzImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedMrzImage;
        [Abstract]
        [NullAllowed, Export("encodedMrzImage")]
        NSData EncodedMrzImage { get; }
    }

    // @interface MBMrtdRecognizerResult : MBTemplatingRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBTemplatingRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMrtdRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic, strong) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult", ArgumentSemantic.Strong)]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) MBOcrLayout * _Nullable rawOcrLayout;
        [NullAllowed, Export("rawOcrLayout")]
        MBOcrLayout RawOcrLayout { get; }
    }

    // @interface MBMrtdSpecification : NSObject <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBMrtdSpecification : INSCopying
    {
        // +(instancetype _Nonnull)createFromPreset:(MBMrtdSpecificationPreset)preset;
        [Static]
        [Export("createFromPreset:")]
        MBMrtdSpecification CreateFromPreset(MBMrtdSpecificationPreset preset);
    }

    // @protocol MBGlareDetection
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface IMBGlareDetection
    {
        // @required @property (assign, nonatomic) BOOL detectGlare;
        [Abstract]
        [Export("detectGlare")]
        bool DetectGlare { get; set; }
    }

    // @protocol MBMrzImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface MBMrzImage
    {
        // @required @property (assign, nonatomic) BOOL returnMrzImage;
        [Abstract]
        [Export("returnMrzImage")]
        bool ReturnMrzImage { get; set; }
    }

    // @protocol MBMrzImageDpi
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface MBMrzImageDpi
    {
        // @required @property (assign, nonatomic) NSInteger mrzImageDpi;
        [Abstract]
        [Export("mrzImageDpi")]
        nint MrzImageDpi { get; set; }
    }

    // @protocol MBEncodeMrzImage
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface MBEncodeMrzImage
    {
        // @required @property (assign, nonatomic) BOOL encodeMrzImage;
        [Abstract]
        [Export("encodeMrzImage")]
        bool EncodeMrzImage { get; set; }
    }

    // @interface MBMrtdRecognizer : MBTemplatingRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBGlareDetection>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBTemplatingRecognizer))]
    interface MBMrtdRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBMrtdRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBMrtdRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL allowUnparsedResults;
        [Export("allowUnparsedResults")]
        bool AllowUnparsedResults { get; set; }

        // @property (assign, nonatomic) BOOL allowUnverifiedResults;
        [Export("allowUnverifiedResults")]
        bool AllowUnverifiedResults { get; set; }

        // @property (assign, nonatomic) BOOL allowSpecialCharacters;
        [Export("allowSpecialCharacters")]
        bool AllowSpecialCharacters { get; set; }

        // -(void)setMrtdSpecifications:(NSArray<__kindof MBMrtdSpecification *> * _Nullable)mrtdSpecifications;
        [Export("setMrtdSpecifications:")]
        void SetMrtdSpecifications([NullAllowed] MBMrtdSpecification[] mrtdSpecifications);

        // @property (readonly, nonatomic, strong) NSArray<__kindof MBMrtdSpecification *> * _Nullable mrtdSpecifications;
        [NullAllowed, Export("mrtdSpecifications", ArgumentSemantic.Strong)]
        MBMrtdSpecification[] MrtdSpecifications { get; }

        [Wrap("WeakMrzFilterDelegate")]
        [NullAllowed]
        MBMrzFilter MrzFilterDelegate { get; set; }

        // @property (nonatomic, weak) id<MBMrzFilter> _Nullable mrzFilterDelegate;
        [NullAllowed, Export("mrzFilterDelegate", ArgumentSemantic.Weak)]
        NSObject WeakMrzFilterDelegate { get; set; }
    }

    // @protocol MBMrzFilter <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBMrzFilter
    {
        // @required -(BOOL)mrzFilter;
        [Abstract]
        [Export("mrzFilter")]
        bool MrzFilter { get; }
    }

    // @interface MBMrtdCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBEncodedFaceImageResult, MBEncodedCombinedFullDocumentImageResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMrtdCombinedRecognizerResult : INSCopying, IMBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBEncodedFaceImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic, strong) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult", ArgumentSemantic.Strong)]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBMrtdCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBMrtdCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi
    {
        // @property (readonly, nonatomic, strong) MBMrtdCombinedRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBMrtdCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL allowUnparsedResults;
        [Export("allowUnparsedResults")]
        bool AllowUnparsedResults { get; set; }

        // @property (assign, nonatomic) BOOL allowUnverifiedResults;
        [Export("allowUnverifiedResults")]
        bool AllowUnverifiedResults { get; set; }

        // @property (assign, nonatomic) BOOL allowSpecialCharacters;
        [Export("allowSpecialCharacters")]
        bool AllowSpecialCharacters { get; set; }

        // @property (assign, nonatomic) NSInteger numStableDetectionsThreshold;
        [Export("numStableDetectionsThreshold")]
        nint NumStableDetectionsThreshold { get; set; }

        // @property (assign, nonatomic) MBDocumentFaceDetectorType detectorType;
        [Export("detectorType", ArgumentSemantic.Assign)]
        MBDocumentFaceDetectorType DetectorType { get; set; }

        [Wrap("WeakMrzCombinedFilterDelegate")]
        [NullAllowed]
        MBMrzCombinedFilter MrzCombinedFilterDelegate { get; set; }

        // @property (nonatomic, weak) id<MBMrzCombinedFilter> _Nullable mrzCombinedFilterDelegate;
        [NullAllowed, Export("mrzCombinedFilterDelegate", ArgumentSemantic.Weak)]
        NSObject WeakMrzCombinedFilterDelegate { get; set; }
    }

    // @protocol MBMrzCombinedFilter <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBMrzCombinedFilter
    {
        // @required -(BOOL)mrzCombinedFilter;
        [Abstract]
        [Export("mrzCombinedFilter")]
        bool MrzCombinedFilter { get; }
    }

    // @interface MBPassportRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBPassportRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBPassportRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBPassportRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBPassportRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBPassportRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL anonymizeNetherlandsMrz;
        [Export("anonymizeNetherlandsMrz")]
        bool AnonymizeNetherlandsMrz { get; set; }
    }

    // @interface MBVisaRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBVisaRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBVisaRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBVisaRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBVisaRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBVisaRecognizerResult Result { get; }
    }

    // @interface MBUsdlCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBFullDocumentImageResult, MBEncodedFaceImageResult, MBEncodedFullDocumentImageResult, MBAgeResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUsdlCombinedRecognizerResult : INSCopying, IMBCombinedRecognizerResult, IMBFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFaceImageResult, IMBEncodedFullDocumentImageResult, IMBAgeResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable middleName;
        [NullAllowed, Export("middleName")]
        string MiddleName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nameSuffix;
        [NullAllowed, Export("nameSuffix")]
        string NameSuffix { get; }

        // @property (readonly, nonatomic) NSString * _Nullable fullName;
        [NullAllowed, Export("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable restrictions;
        [NullAllowed, Export("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nullable endorsements;
        [NullAllowed, Export("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nullable vehicleClass;
        [NullAllowed, Export("vehicleClass")]
        string VehicleClass { get; }

        // -(NSData * _Nullable)data;
        [NullAllowed, Export("data")]
        NSData Data { get; }

        // -(BOOL)isUncertain;
        [Export("isUncertain")]
        bool IsUncertain { get; }

        // -(NSString * _Nullable)getField:(MBUsdlKeys)usdlKey;
        [Export("getField:")]
        [return: NullAllowed]
        string GetField(MBUsdlKeys usdlKey);

        // -(NSArray<NSString *> * _Nullable)optionalElements __attribute__((deprecated("")));
        [NullAllowed, Export("optionalElements")]
        string[] OptionalElements { get; }
    }

    // @interface MBUsdlCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBFaceImageDpi, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBFullDocumentImageExtensionFactors>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBUsdlCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBUsdlCombinedRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBUsdlCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL allowNullQuietZone;
        [Export("allowNullQuietZone")]
        bool AllowNullQuietZone { get; set; }

        // @property (assign, nonatomic) BOOL enableCompactParser;
        [Export("enableCompactParser")]
        bool EnableCompactParser { get; set; }

        // @property (assign, nonatomic) MBDocumentFaceDetectorType type;
        [Export("type", ArgumentSemantic.Assign)]
        MBDocumentFaceDetectorType Type { get; set; }

        // @property (assign, nonatomic) NSInteger numStableDetectionsThreshold;
        [Export("numStableDetectionsThreshold")]
        nint NumStableDetectionsThreshold { get; set; }
    }

    // @interface MBProcessorResult : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBProcessorResult
    {
        // @property (readonly, assign, nonatomic) MBProcessorResultState resultState;
        [Export("resultState", ArgumentSemantic.Assign)]
        MBProcessorResultState ResultState { get; }
    }

    // @interface MBProcessor : MBEntity
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBEntity))]
    interface MBProcessor
    {
        // @property (readonly, nonatomic, weak) MBProcessorResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBProcessorResult BaseResult { get; }
    }

    // @interface MBParserGroupProcessorResult : MBProcessorResult <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBProcessorResult))]
    [DisableDefaultCtor]
    interface MBParserGroupProcessorResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBOcrLayout * _Nonnull ocrLayout;
        [Export("ocrLayout", ArgumentSemantic.Strong)]
        MBOcrLayout OcrLayout { get; }
    }

    /*
    // @interface MBParserGroupProcessor : MBProcessor <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBProcessor))]
    [DisableDefaultCtor]
    interface MBParserGroupProcessor : INSCopying
    {
        // -(instancetype _Nonnull)initWithParsers:(NSArray<MBParser *> * _Nonnull)parsers __attribute__((objc_designated_initializer));
        [Export("initWithParsers:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBParser[] parsers);

        // @property (readonly, nonatomic, strong) NSArray<MBParser *> * _Nonnull parsers;
        [Export("parsers", ArgumentSemantic.Strong)]
        MBParser[] Parsers { get; }

        // @property (readonly, nonatomic, strong) MBParserGroupProcessorResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBParserGroupProcessorResult Result { get; }

        // @property (assign, nonatomic) BOOL oneOptionalElementInGroupShouldBeValid;
        [Export("oneOptionalElementInGroupShouldBeValid")]
        bool OneOptionalElementInGroupShouldBeValid { get; set; }
    }
    */

    // @interface MBImageReturnProcessorResult : MBProcessorResult <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBProcessorResult))]
    [DisableDefaultCtor]
    interface MBImageReturnProcessorResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBImage * _Nullable rawImage;
        [NullAllowed, Export("rawImage", ArgumentSemantic.Strong)]
        MBImage RawImage { get; }

        // @property (readonly, nonatomic, strong) NSData * _Nullable encodedImage;
        [NullAllowed, Export("encodedImage", ArgumentSemantic.Strong)]
        NSData EncodedImage { get; }
    }

    // @interface MBImageReturnProcessor : MBProcessor <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBProcessor))]
    interface MBImageReturnProcessor : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBImageReturnProcessorResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBImageReturnProcessorResult Result { get; }

        // @property (assign, nonatomic) BOOL encodeImage;
        [Export("encodeImage")]
        bool EncodeImage { get; set; }
    }

    // @interface MBProcessorGroup : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBProcessorGroup
    {
        // -(instancetype _Nonnull)initWithProcessingLocation:(CGRect)processingLocation dewarpPolicy:(MBDewarpPolicy * _Nonnull)dewarpPolicy andProcessors:(NSArray<__kindof MBProcessor *> * _Nonnull)processors __attribute__((objc_designated_initializer));
        [Export("initWithProcessingLocation:dewarpPolicy:andProcessors:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect processingLocation, MBDewarpPolicy dewarpPolicy, MBProcessor[] processors);

        // @property (readonly, nonatomic, strong) NSArray<__kindof MBProcessor *> * _Nonnull processors;
        [Export("processors", ArgumentSemantic.Strong)]
        MBProcessor[] Processors { get; }
    }

    // @interface MBTemplatingClass : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBTemplatingClass
    {
        // -(void)setClassificationProcessorGroups:(NSArray<__kindof MBProcessorGroup *> * _Nonnull)processorGroups;
        [Export("setClassificationProcessorGroups:")]
        void SetClassificationProcessorGroups(MBProcessorGroup[] processorGroups);

        // -(NSArray<__kindof MBProcessorGroup *> * _Nullable)getClassificationProcessorGroups;
        [NullAllowed, Export("getClassificationProcessorGroups")]
        MBProcessorGroup[] ClassificationProcessorGroups { get; }

        // -(void)setNonClassificationProcessorGroups:(NSArray<__kindof MBProcessorGroup *> * _Nonnull)processorGroups;
        [Export("setNonClassificationProcessorGroups:")]
        void SetNonClassificationProcessorGroups(MBProcessorGroup[] processorGroups);

        // -(NSArray<__kindof MBProcessorGroup *> * _Nullable)getNonClassificationProcessorGroups;
        [NullAllowed, Export("getNonClassificationProcessorGroups")]
        MBProcessorGroup[] NonClassificationProcessorGroups { get; }

        // -(void)setTemplatingClassifier:(id<MBTemplatingClassifier> _Nullable)templatingClassifier;
        [Export("setTemplatingClassifier:")]
        void SetTemplatingClassifier([NullAllowed] MBTemplatingClassifier templatingClassifier);
    }

    // @protocol MBTemplatingClassifier <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBTemplatingClassifier
    {
        // @required -(BOOL)classify;
        [Abstract]
        [Export("classify")]
        bool Classify { get; }
    }

    // @interface MBDewarpPolicy : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBDewarpPolicy
    {
    }

    // @interface MBFixedDewarpPolicy : MBDewarpPolicy
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBDewarpPolicy))]
    interface MBFixedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDewarpHeight:(NSInteger)dewarpHeight __attribute__((objc_designated_initializer));
        [Export("initWithDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint dewarpHeight);

        // @property (readonly, assign, nonatomic) NSInteger dewarpHeight;
        [Export("dewarpHeight")]
        nint DewarpHeight { get; }
    }

    // @interface MBDPIBasedDewarpPolicy : MBDewarpPolicy
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBDewarpPolicy))]
    interface MBDPIBasedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDesiredDPI:(NSInteger)desiredDPI __attribute__((objc_designated_initializer));
        [Export("initWithDesiredDPI:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint desiredDPI);

        // @property (readonly, assign, nonatomic) NSInteger desiredDPI;
        [Export("desiredDPI")]
        nint DesiredDPI { get; }
    }

    // @interface MBNoUpScalingDewarpPolicy : MBDewarpPolicy
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBDewarpPolicy))]
    interface MBNoUpScalingDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithMaxAllowedDewarpHeight:(NSInteger)maxAllowedDewarpHeight __attribute__((objc_designated_initializer));
        [Export("initWithMaxAllowedDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint maxAllowedDewarpHeight);

        // @property (readonly, assign, nonatomic) NSInteger maxAllowedDewarpHeight;
        [Export("maxAllowedDewarpHeight")]
        nint MaxAllowedDewarpHeight { get; }
    }

    // @interface MBDisplayableObject : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBDisplayableObject
    {
        // @property (assign, nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }
    }

    // @interface MBDisplayableDetection : MBDisplayableObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBDisplayableObject))]
    [DisableDefaultCtor]
    interface MBDisplayableDetection
    {
        // -(instancetype _Nonnull)initWithDetectionStatus:(MBDetectionStatus)status __attribute__((objc_designated_initializer));
        [Export("initWithDetectionStatus:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBDetectionStatus status);

        // @property (readonly, assign, nonatomic) MBDetectionStatus detectionStatus;
        [Export("detectionStatus", ArgumentSemantic.Assign)]
        MBDetectionStatus DetectionStatus { get; }
    }

    // @interface MBDisplayableQuadDetection : MBDisplayableDetection
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBDisplayableDetection))]
    interface MBDisplayableQuadDetection
    {
        // @property (nonatomic, strong) MBQuadrangle * _Nonnull detectionLocation;
        [Export("detectionLocation", ArgumentSemantic.Strong)]
        MBQuadrangle DetectionLocation { get; set; }
    }

    // @protocol MBQuadDetectorSubview <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBQuadDetectorSubview
    {
        // @required -(void)detectionFinishedWithDisplayableQuad:(MBDisplayableQuadDetection *)displayableQuadDetection;
        [Abstract]
        [Export("detectionFinishedWithDisplayableQuad:")]
        void DetectionFinishedWithDisplayableQuad(MBDisplayableQuadDetection displayableQuadDetection);

        // @required -(void)detectionFinishedWithDisplayableQuad:(MBDisplayableQuadDetection *)displayableQuadDetection originalRectangle:(CGRect)originalRect relativeRectangle:(CGRect)relativeRectangle;
        [Abstract]
        [Export("detectionFinishedWithDisplayableQuad:originalRectangle:relativeRectangle:")]
        void OriginalRectangle(MBDisplayableQuadDetection displayableQuadDetection, CGRect originalRect, CGRect relativeRectangle);
    }

    // @interface MBBarcodeVehicleClassInfo : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBBarcodeVehicleClassInfo
    {
        // @property (readonly, nonatomic) NSString * _Nonnull vehicleClass;
        [Export("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceType;
        [Export("licenceType")]
        string LicenceType { get; }

        // @property (readonly, nonatomic) MBDate * _Nullable effectiveDate;
        [NullAllowed, Export("effectiveDate")]
        MBDate EffectiveDate { get; }

        // @property (readonly, nonatomic) MBDate * _Nullable expiryDate;
        [NullAllowed, Export("expiryDate")]
        MBDate ExpiryDate { get; }

        // -(instancetype _Nonnull)initWithVehicleClass:(NSString * _Nonnull)vehicleClass licenceType:(NSString * _Nonnull)licenceType effectiveDate:(MBDate * _Nullable)effectiveDate expiryDate:(MBDate * _Nullable)expiryDate __attribute__((objc_designated_initializer));
        [Export("initWithVehicleClass:licenceType:effectiveDate:expiryDate:")]
        [DesignatedInitializer]
        IntPtr Constructor(string vehicleClass, string licenceType, [NullAllowed] MBDate effectiveDate, [NullAllowed] MBDate expiryDate);
    }

    // @interface MBBarcodeDriverLicenseDetailedInfo : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBBarcodeDriverLicenseDetailedInfo
    {
        // @property (readonly, nonatomic) NSString * _Nullable restrictions;
        [NullAllowed, Export("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nullable endorsements;
        [NullAllowed, Export("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nullable vehicleClass;
        [NullAllowed, Export("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nullable conditions;
        [NullAllowed, Export("conditions")]
        string Conditions { get; }

        // @property (readonly, nonatomic) NSArray<MBBarcodeVehicleClassInfo *> * _Nullable vehicleClassesInfo;
        [NullAllowed, Export("vehicleClassesInfo")]
        MBBarcodeVehicleClassInfo[] VehicleClassesInfo { get; }
    }

    // @interface MBVehicleClassInfo : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVehicleClassInfo
    {
        // @property (readonly, nonatomic) MBStringResult * _Nullable vehicleClass;
        [NullAllowed, Export("vehicleClass")]
        MBStringResult VehicleClass { get; }

        // @property (readonly, nonatomic) MBStringResult * _Nullable licenceType;
        [NullAllowed, Export("licenceType")]
        MBStringResult LicenceType { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable effectiveDate;
        [NullAllowed, Export("effectiveDate")]
        MBDateResult EffectiveDate { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable expiryDate;
        [NullAllowed, Export("expiryDate")]
        MBDateResult ExpiryDate { get; }

        // -(instancetype _Nonnull)initWithVehicleClass:(MBStringResult * _Nullable)vehicleClass licenceType:(MBStringResult * _Nullable)licenceType effectiveDate:(MBDateResult * _Nullable)effectiveDate expiryDate:(MBDateResult * _Nullable)expiryDate __attribute__((objc_designated_initializer));
        [Export("initWithVehicleClass:licenceType:effectiveDate:expiryDate:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] MBStringResult vehicleClass, [NullAllowed] MBStringResult licenceType, [NullAllowed] MBDateResult effectiveDate, [NullAllowed] MBDateResult expiryDate);
    }

    // @interface MBUsdlRecognizerResult : MBRecognizerResult <NSCopying, MBAgeResult>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUsdlRecognizerResult : INSCopying, IMBAgeResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable middleName;
        [NullAllowed, Export("middleName")]
        string MiddleName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable fullName;
        [NullAllowed, Export("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nameSuffix;
        [NullAllowed, Export("nameSuffix")]
        string NameSuffix { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable restrictions;
        [NullAllowed, Export("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nullable endorsements;
        [NullAllowed, Export("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nullable vehicleClass;
        [NullAllowed, Export("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nullable street;
        [NullAllowed, Export("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nullable postalCode;
        [NullAllowed, Export("postalCode")]
        string PostalCode { get; }

        // @property (readonly, nonatomic) NSString * _Nullable city;
        [NullAllowed, Export("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nullable jurisdiction;
        [NullAllowed, Export("jurisdiction")]
        string Jurisdiction { get; }

        // -(NSData * _Nullable)data;
        [NullAllowed, Export("data")]
        NSData Data { get; }

        // -(BOOL)isUncertain;
        [Export("isUncertain")]
        bool IsUncertain { get; }

        // -(NSString * _Nullable)getField:(MBUsdlKeys)usdlKey;
        [Export("getField:")]
        [return: NullAllowed]
        string GetField(MBUsdlKeys usdlKey);

        // -(NSArray<NSString *> * _Nullable)optionalElements __attribute__((deprecated("")));
        [NullAllowed, Export("optionalElements")]
        string[] OptionalElements { get; }
    }

    // @interface MBUsdlRecognizer : MBRecognizer <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBUsdlRecognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBUsdlRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBUsdlRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL allowNullQuietZone;
        [Export("allowNullQuietZone")]
        bool AllowNullQuietZone { get; set; }

        // @property (assign, nonatomic) BOOL enableCompactParser;
        [Export("enableCompactParser")]
        bool EnableCompactParser { get; set; }
    }

    // @interface MBBaseOverlayViewController : MBOverlayViewController
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBOverlayViewController))]
    interface MBBaseOverlayViewController
    {
        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBRecognizerCollection : NSObject <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerCollection : INSCopying
    {
        // -(instancetype _Nonnull)initWithRecognizers:(NSArray<MBRecognizer *> * _Nonnull)recognizers __attribute__((objc_designated_initializer));
        [Export("initWithRecognizers:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizer[] recognizers);

        // @property (nonatomic, strong) NSArray<MBRecognizer *> * _Nonnull recognizerList;
        [Export("recognizerList", ArgumentSemantic.Strong)]
        MBRecognizer[] RecognizerList { get; set; }

        // @property (nonatomic) BOOL allowMultipleResults;
        [Export("allowMultipleResults")]
        bool AllowMultipleResults { get; set; }

        // @property (nonatomic) NSTimeInterval partialRecognitionTimeout;
        [Export("partialRecognitionTimeout")]
        double PartialRecognitionTimeout { get; set; }

        // @property (nonatomic) MBRecognitionDebugMode recognitionDebugMode;
        [Export("recognitionDebugMode", ArgumentSemantic.Assign)]
        MBRecognitionDebugMode RecognitionDebugMode { get; set; }

        // @property (nonatomic) MBFrameQualityEstimationMode frameQualityEstimationMode;
        [Export("frameQualityEstimationMode", ArgumentSemantic.Assign)]
        MBFrameQualityEstimationMode FrameQualityEstimationMode { get; set; }
    }

    // @interface MBOverlaySettings : NSObject <NSCopying>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBOverlaySettings : INSCopying
    {
        // @property (nonatomic, strong) NSString * _Nullable language;
        [NullAllowed, Export("language", ArgumentSemantic.Strong)]
        string Language { get; set; }

        // @property (nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export("cameraSettings", ArgumentSemantic.Strong)]
        MBCameraSettings CameraSettings { get; set; }
    }

    // @interface MBBaseOverlaySettings : MBOverlaySettings
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBOverlaySettings))]
    interface MBBaseOverlaySettings
    {
        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Export("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable soundFilePath;
        [NullAllowed, Export("soundFilePath", ArgumentSemantic.Strong)]
        string SoundFilePath { get; set; }

        // @property (assign, nonatomic) BOOL displayCancelButton;
        [Export("displayCancelButton")]
        bool DisplayCancelButton { get; set; }

        // @property (assign, nonatomic) BOOL displayTorchButton;
        [Export("displayTorchButton")]
        bool DisplayTorchButton { get; set; }
    }

    // @interface MBBaseOcrOverlaySettings : MBBaseOverlaySettings
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBBaseOverlaySettings))]
    interface MBBaseOcrOverlaySettings
    {
        // @property (nonatomic) BOOL showOcrDots;
        [Export("showOcrDots")]
        bool ShowOcrDots { get; set; }
    }

    // @interface MBDocumentOverlaySettings : MBBaseOcrOverlaySettings
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBBaseOcrOverlaySettings))]
    interface MBDocumentOverlaySettings
    {
        // @property (nonatomic, strong) NSString * _Nonnull tooltipText;
        [Export("tooltipText", ArgumentSemantic.Strong)]
        string TooltipText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull glareStatusMessage;
        [Export("glareStatusMessage", ArgumentSemantic.Strong)]
        string GlareStatusMessage { get; set; }

        // @property (assign, nonatomic) BOOL showTooltip;
        [Export("showTooltip")]
        bool ShowTooltip { get; set; }

        // @property (assign, nonatomic) BOOL captureHighResImage;
        [Export("captureHighResImage")]
        bool CaptureHighResImage { get; set; }
    }

    // @interface MBDocumentOverlayViewController : MBBaseOverlayViewController
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBDocumentOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBDocumentOverlaySettings * _Nonnull settings;
        [Export("settings", ArgumentSemantic.Strong)]
        MBDocumentOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBDocumentOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBDocumentOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBDocumentOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBDocumentOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBDocumentOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBDocumentOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBDocumentOverlayViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBDocumentOverlayViewControllerDelegate
    {
        // @required -(void)documentOverlayViewControllerDidFinishScanning:(MBDocumentOverlayViewController * _Nonnull)documentOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("documentOverlayViewControllerDidFinishScanning:state:")]
        void DocumentOverlayViewControllerDidFinishScanning(MBDocumentOverlayViewController documentOverlayViewController, MBRecognizerResultState state);

        // @required -(void)documentOverlayViewControllerDidTapClose:(MBDocumentOverlayViewController * _Nonnull)documentOverlayViewController;
        [Abstract]
        [Export("documentOverlayViewControllerDidTapClose:")]
        void DocumentOverlayViewControllerDidTapClose(MBDocumentOverlayViewController documentOverlayViewController);

        // @optional -(void)documentOverlayViewControllerDidCaptureHighResolutionImage:(MBDocumentOverlayViewController * _Nonnull)documentOverlayViewController highResImage:(MBImage * _Nonnull)highResImage;
        [Export("documentOverlayViewControllerDidCaptureHighResolutionImage:highResImage:")]
        void DocumentOverlayViewControllerDidCaptureHighResolutionImage(MBDocumentOverlayViewController documentOverlayViewController, MBImage highResImage);
    }

    // @interface MBLegacyDocumentVerificationOverlaySettings : MBBaseOcrOverlaySettings
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBBaseOcrOverlaySettings))]
    interface MBLegacyDocumentVerificationOverlaySettings
    {
        // @property (nonatomic, strong) NSString * _Nonnull firstSideInstructions;
        [Export("firstSideInstructions", ArgumentSemantic.Strong)]
        string FirstSideInstructions { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull secondSideInstructions;
        [Export("secondSideInstructions", ArgumentSemantic.Strong)]
        string SecondSideInstructions { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull firstSideSplashMessage;
        [Export("firstSideSplashMessage", ArgumentSemantic.Strong)]
        string FirstSideSplashMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull secondSideSplashMessage;
        [Export("secondSideSplashMessage", ArgumentSemantic.Strong)]
        string SecondSideSplashMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull scanningDoneSplashMessage;
        [Export("scanningDoneSplashMessage", ArgumentSemantic.Strong)]
        string ScanningDoneSplashMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull glareMessage;
        [Export("glareMessage", ArgumentSemantic.Strong)]
        string GlareMessage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull firstSideSplashImage;
        [Export("firstSideSplashImage", ArgumentSemantic.Strong)]
        UIImage FirstSideSplashImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull secondSideSplashImage;
        [Export("secondSideSplashImage", ArgumentSemantic.Strong)]
        UIImage SecondSideSplashImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull firstSideInstructionsImage;
        [Export("firstSideInstructionsImage", ArgumentSemantic.Strong)]
        UIImage FirstSideInstructionsImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull secondSideInstructionsImage;
        [Export("secondSideInstructionsImage", ArgumentSemantic.Strong)]
        UIImage SecondSideInstructionsImage { get; set; }

        // @property (assign, nonatomic) BOOL captureHighResImage;
        [Export("captureHighResImage")]
        bool CaptureHighResImage { get; set; }
    }

    // @interface MBLegacyDocumentVerificationOverlayViewController : MBBaseOverlayViewController
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBLegacyDocumentVerificationOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBLegacyDocumentVerificationOverlaySettings * _Nonnull settings;
        [Export("settings", ArgumentSemantic.Strong)]
        MBLegacyDocumentVerificationOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBLegacyDocumentVerificationOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBLegacyDocumentVerificationOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBLegacyDocumentVerificationOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBLegacyDocumentVerificationOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBLegacyDocumentVerificationOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBLegacyDocumentVerificationOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBLegacyDocumentVerificationOverlayViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBLegacyDocumentVerificationOverlayViewControllerDelegate
    {
        // @required -(void)legacyDocumentVerificationOverlayViewControllerDidFinishScanning:(MBLegacyDocumentVerificationOverlayViewController * _Nonnull)documentVerificationOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("legacyDocumentVerificationOverlayViewControllerDidFinishScanning:state:")]
        void LegacyDocumentVerificationOverlayViewControllerDidFinishScanning(MBLegacyDocumentVerificationOverlayViewController documentVerificationOverlayViewController, MBRecognizerResultState state);

        // @required -(void)legacyDocumentVerificationOverlayViewControllerDidTapClose:(MBLegacyDocumentVerificationOverlayViewController * _Nonnull)documentVerificationOverlayViewController;
        [Abstract]
        [Export("legacyDocumentVerificationOverlayViewControllerDidTapClose:")]
        void LegacyDocumentVerificationOverlayViewControllerDidTapClose(MBLegacyDocumentVerificationOverlayViewController documentVerificationOverlayViewController);

        // @optional -(void)legacyDocumentVerificationOverlayViewControllerDidFinishScanningFirstSide:(MBLegacyDocumentVerificationOverlayViewController * _Nonnull)documentVerificationOverlayViewController;
        [Export("legacyDocumentVerificationOverlayViewControllerDidFinishScanningFirstSide:")]
        void LegacyDocumentVerificationOverlayViewControllerDidFinishScanningFirstSide(MBLegacyDocumentVerificationOverlayViewController documentVerificationOverlayViewController);

        // @optional -(void)legacyDocumentVerificationOverlayViewControllerDidCaptureHighResolutionImage:(MBLegacyDocumentVerificationOverlayViewController * _Nonnull)documentVerificationOverlayViewController highResImage:(MBImage * _Nonnull)highResImage state:(MBLegacyDocumentVerificationHighResImageState)state;
        [Export("legacyDocumentVerificationOverlayViewControllerDidCaptureHighResolutionImage:highResImage:state:")]
        void LegacyDocumentVerificationOverlayViewControllerDidCaptureHighResolutionImage(MBLegacyDocumentVerificationOverlayViewController documentVerificationOverlayViewController, MBImage highResImage, MBLegacyDocumentVerificationHighResImageState state);
    }

    // @interface MBBlinkIdOverlayViewController : MBBaseOverlayViewController <MBBlinkIdMultiSideRecognizerDelegate, MBBlinkIdSingleSideRecognizerDelegate>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBBlinkIdOverlayViewController : IMBBlinkIdMultiSideRecognizerDelegate, IMBBlinkIdSingleSideRecognizerDelegate
    {
        // @property (readonly, nonatomic) MBBlinkIdOverlaySettings * _Nonnull settings;
        [Export("settings")]
        MBBlinkIdOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBBlinkIdOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBBlinkIdOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBBlinkIdOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBBlinkIdOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBBlinkIdOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBBlinkIdOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBBlinkIdOverlayViewControllerDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBBlinkIdOverlayViewControllerDelegate
    {
        // @required -(void)blinkIdOverlayViewControllerDidFinishScanning:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("blinkIdOverlayViewControllerDidFinishScanning:state:")]
        void BlinkIdOverlayViewControllerDidFinishScanning(MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state);

        // @required -(void)blinkIdOverlayViewControllerDidTapClose:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController;
        [Abstract]
        [Export("blinkIdOverlayViewControllerDidTapClose:")]
        void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController);

        // @optional -(void)blinkIdOverlayViewControllerDidFinishScanningFirstSide:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController;
        [Export("blinkIdOverlayViewControllerDidFinishScanningFirstSide:")]
        void BlinkIdOverlayViewControllerDidFinishScanningFirstSide(MBBlinkIdOverlayViewController blinkIdOverlayViewController);
    }

    // @interface MBBlinkIdOverlaySettings : MBBaseOverlaySettings
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBBaseOverlaySettings))]
    interface MBBlinkIdOverlaySettings
    {
        // @property (assign, nonatomic) BOOL requireDocumentSidesDataMatch;
        [Export("requireDocumentSidesDataMatch")]
        bool RequireDocumentSidesDataMatch { get; set; }

        // @property (assign, nonatomic) BOOL showNotSupportedDialog;
        [Export("showNotSupportedDialog")]
        bool ShowNotSupportedDialog { get; set; }

        // @property (assign, nonatomic) BOOL showFlashlightWarning;
        [Export("showFlashlightWarning")]
        bool ShowFlashlightWarning { get; set; }

        // @property (assign, nonatomic) NSTimeInterval backSideScanningTimeout;
        [Export("backSideScanningTimeout")]
        double BackSideScanningTimeout { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull firstSideInstructionsText;
        [Export("firstSideInstructionsText", ArgumentSemantic.Strong)]
        string FirstSideInstructionsText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull backSideInstructionsText;
        [Export("backSideInstructionsText", ArgumentSemantic.Strong)]
        string BackSideInstructionsText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull scanBarcodeText;
        [Export("scanBarcodeText", ArgumentSemantic.Strong)]
        string ScanBarcodeText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull flipInstructions;
        [Export("flipInstructions", ArgumentSemantic.Strong)]
        string FlipInstructions { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorMoveCloser;
        [Export("errorMoveCloser", ArgumentSemantic.Strong)]
        string ErrorMoveCloser { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorMoveFarther;
        [Export("errorMoveFarther", ArgumentSemantic.Strong)]
        string ErrorMoveFarther { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorDocumentTooCloseToEdge;
        [Export("errorDocumentTooCloseToEdge", ArgumentSemantic.Strong)]
        string ErrorDocumentTooCloseToEdge { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull sidesNotMatchingTitle;
        [Export("sidesNotMatchingTitle", ArgumentSemantic.Strong)]
        string SidesNotMatchingTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull sidesNotMatchingMessage;
        [Export("sidesNotMatchingMessage", ArgumentSemantic.Strong)]
        string SidesNotMatchingMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull dataMismatchTitle;
        [Export("dataMismatchTitle", ArgumentSemantic.Strong)]
        string DataMismatchTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull dataMismatchMessage;
        [Export("dataMismatchMessage", ArgumentSemantic.Strong)]
        string DataMismatchMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull unsupportedDocumentTitle;
        [Export("unsupportedDocumentTitle", ArgumentSemantic.Strong)]
        string UnsupportedDocumentTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull unsupportedDocumentMessage;
        [Export("unsupportedDocumentMessage", ArgumentSemantic.Strong)]
        string UnsupportedDocumentMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recognitionTimeoutTitle;
        [Export("recognitionTimeoutTitle", ArgumentSemantic.Strong)]
        string RecognitionTimeoutTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recognitionTimeoutMessage;
        [Export("recognitionTimeoutMessage", ArgumentSemantic.Strong)]
        string RecognitionTimeoutMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull retryButtonText;
        [Export("retryButtonText", ArgumentSemantic.Strong)]
        string RetryButtonText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorMandatoryFieldMissing;
        [Export("errorMandatoryFieldMissing", ArgumentSemantic.Strong)]
        string ErrorMandatoryFieldMissing { get; set; }

        // @property (assign, nonatomic) BOOL defineSpecificMissingMandatoryFields;
        [Export("defineSpecificMissingMandatoryFields")]
        bool DefineSpecificMissingMandatoryFields { get; set; }

        // @property (assign, nonatomic) NSTimeInterval onboardingButtonTooltipDelay;
        [Export("onboardingButtonTooltipDelay")]
        double OnboardingButtonTooltipDelay { get; set; }

        // @property (assign, nonatomic) BOOL showOnboardingInfo;
        [Export("showOnboardingInfo")]
        bool ShowOnboardingInfo { get; set; }

        // @property (assign, nonatomic) BOOL showIntroductionDialog;
        [Export("showIntroductionDialog")]
        bool ShowIntroductionDialog { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull glareDetectedMessage;
        [Export("glareDetectedMessage", ArgumentSemantic.Strong)]
        string GlareDetectedMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull blurDetectedMessage;
        [Export("blurDetectedMessage", ArgumentSemantic.Strong)]
        string BlurDetectedMessage { get; set; }
    }

    // @interface MBCustomOverlayViewController : MBOverlayViewController
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBOverlayViewController))]
    interface MBCustomOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBRecognizerCollection * _Nonnull recognizerCollection;
        [Export("recognizerCollection", ArgumentSemantic.Strong)]
        MBRecognizerCollection RecognizerCollection { get; }

        // @property (readonly, nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export("cameraSettings", ArgumentSemantic.Strong)]
        MBCameraSettings CameraSettings { get; }

        // @property (nonatomic, strong) MBRecognizerRunnerViewControllerMetadataDelegates * _Nonnull metadataDelegates;
        [Export("metadataDelegates", ArgumentSemantic.Strong)]
        MBRecognizerRunnerViewControllerMetadataDelegates MetadataDelegates { get; set; }

        [Wrap("WeakScanningRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBScanningRecognizerRunnerViewControllerDelegate ScanningRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBScanningRecognizerRunnerViewControllerDelegate> _Nullable scanningRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("scanningRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakScanningRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBRecognizerRunnerViewControllerDelegate RecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBRecognizerRunnerViewControllerDelegate> _Nullable recognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("recognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakRecognizerRunnerViewControllerDelegate { get; set; }

        // -(instancetype _Nonnull)initWithRecognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection cameraSettings:(MBCameraSettings * _Nonnull)cameraSettings __attribute__((objc_designated_initializer));
        [Export("initWithRecognizerCollection:cameraSettings:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizerCollection recognizerCollection, MBCameraSettings cameraSettings);

        // @property (nonatomic) CGRect scanningRegion;
        [Export("scanningRegion", ArgumentSemantic.Assign)]
        CGRect ScanningRegion { get; set; }

        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Export("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBSubview : UIView
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(UIView))]
    interface MBSubview
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBSubviewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBSubviewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol MBSubviewDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBSubviewDelegate
    {
        // @required -(void)subviewAnimationDidStart:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export("subviewAnimationDidStart:")]
        void SubviewAnimationDidStart(MBSubview subview);

        // @required -(void)subviewAnimationDidFinish:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export("subviewAnimationDidFinish:")]
        void SubviewAnimationDidFinish(MBSubview subview);
    }

    /*
    // @interface MBDocumentSubview : MBSubview
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    interface MBDocumentSubview
    {
        // @property (nonatomic) UIView * _Nonnull viewfinderView;
        [Export("viewfinderView", ArgumentSemantic.Assign)]
        UIView ViewfinderView { get; set; }

        // @property (nonatomic) CGFloat viewfinderWidthToHeightRatio;
        [Export("viewfinderWidthToHeightRatio")]
        nfloat ViewfinderWidthToHeightRatio { get; set; }

        // @property (nonatomic) UILabel * _Nonnull tooltipLabel;
        [Export("tooltipLabel", ArgumentSemantic.Assign)]
        UILabel TooltipLabel { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder;
        [Export("initWithCoder:")]
        IntPtr Constructor(NSCoder aDecoder);
    }
    */

    // @interface MBLegacyDocumentVerificationSubview : MBSubview
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    interface MBLegacyDocumentVerificationSubview
    {
        // @property (nonatomic) UILabel * _Nonnull helpLabel;
        [Export("helpLabel", ArgumentSemantic.Assign)]
        UILabel HelpLabel { get; set; }

        // @property (nonatomic) UIImageView * _Nonnull helpImageView;
        [Export("helpImageView", ArgumentSemantic.Assign)]
        UIImageView HelpImageView { get; set; }

        // -(void)animateHelp;
        [Export("animateHelp")]
        void AnimateHelp();

        [Wrap("WeakDocumentVerificationSubviewDelegate")]
        [NullAllowed]
        MBLegacyDocumentVerificationSubviewDelegate DocumentVerificationSubviewDelegate { get; set; }

        // @property (nonatomic, weak) id<MBLegacyDocumentVerificationSubviewDelegate> _Nullable documentVerificationSubviewDelegate;
        [NullAllowed, Export("documentVerificationSubviewDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDocumentVerificationSubviewDelegate { get; set; }
    }

    // @protocol MBLegacyDocumentVerificationSubviewDelegate <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBLegacyDocumentVerificationSubviewDelegate
    {
        // @required -(void)documentVerificationSubviewDidFinishAnimation:(MBLegacyDocumentVerificationSubview * _Nonnull)documentVerificationSubview;
        [Abstract]
        [Export("documentVerificationSubviewDidFinishAnimation:")]
        void DocumentVerificationSubviewDidFinishAnimation(MBLegacyDocumentVerificationSubview documentVerificationSubview);
    }

    // @interface MBLegacyDocumentVerificationInstructionsSubview : MBSubview
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    interface MBLegacyDocumentVerificationInstructionsSubview
    {
        // @property (nonatomic) UILabel * _Nonnull instructionsLabel;
        [Export("instructionsLabel", ArgumentSemantic.Assign)]
        UILabel InstructionsLabel { get; set; }

        // @property (nonatomic) UIImageView * _Nonnull instructionsImageView;
        [Export("instructionsImageView", ArgumentSemantic.Assign)]
        UIImageView InstructionsImageView { get; set; }
    }

    // @interface MBCameraReticle : MBSubview
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    interface MBCameraReticle
    {
        // @property (nonatomic) BOOL isAnimating;
        [Export("isAnimating")]
        bool IsAnimating { get; set; }

        // @property (nonatomic) BOOL isDetecting;
        [Export("isDetecting")]
        bool IsDetecting { get; set; }

        // @property (nonatomic) BOOL isConfirming;
        [Export("isConfirming")]
        bool IsConfirming { get; set; }

        // -(void)startAnimating;
        [Export("startAnimating")]
        void StartAnimating();

        // -(void)stopAnimating;
        [Export("stopAnimating")]
        void StopAnimating();

        // -(void)startDetecting;
        [Export("startDetecting")]
        void StartDetecting();

        // -(void)stopDetecting;
        [Export("stopDetecting")]
        void StopDetecting();

        // -(void)resetAll;
        [Export("resetAll")]
        void ResetAll();

        // -(void)animateArcRotation;
        [Export("animateArcRotation")]
        void AnimateArcRotation();

        // @property (nonatomic, strong) UIImage * _Nullable reticleImage;
        [NullAllowed, Export("reticleImage", ArgumentSemantic.Strong)]
        UIImage ReticleImage { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull reticleColor;
        [Export("reticleColor", ArgumentSemantic.Strong)]
        UIColor ReticleColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull reticleDefaultColor;
        [Export("reticleDefaultColor", ArgumentSemantic.Strong)]
        UIColor ReticleDefaultColor { get; set; }
    }

    // @interface MBErrorReticle : MBSubview
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    interface MBErrorReticle
    {
        // @property (nonatomic, strong) UIColor * _Nonnull errorColor;
        [Export("errorColor", ArgumentSemantic.Strong)]
        UIColor ErrorColor { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull errorReticleImage;
        [Export("errorReticleImage", ArgumentSemantic.Strong)]
        UIImage ErrorReticleImage { get; set; }
    }

    // @interface MBDisplayablePointsDetection : MBDisplayableDetection
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBDisplayableDetection))]
    interface MBDisplayablePointsDetection
    {
        // @property (nonatomic) NSArray * _Nonnull points;
        [Export("points", ArgumentSemantic.Assign)]
        NSObject[] Points { get; set; }
    }

    // @protocol MBPointDetectorSubview <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface IMBPointDetectorSubview
    {
        // @required -(void)detectionFinishedWithDisplayablePoints:(MBDisplayablePointsDetection *)displayablePointsDetection;
        [Abstract]
        [Export("detectionFinishedWithDisplayablePoints:")]
        void DetectionFinishedWithDisplayablePoints(MBDisplayablePointsDetection displayablePointsDetection);

        // @required -(void)detectionFinishedWithDisplayablePoints:(MBDisplayablePointsDetection *)displayablePointsDetection originalRectangle:(CGRect)originalRect relativeRectangle:(CGRect)relativeRectangle;
        [Abstract]
        [Export("detectionFinishedWithDisplayablePoints:originalRectangle:relativeRectangle:")]
        void OriginalRectangle(MBDisplayablePointsDetection displayablePointsDetection, CGRect originalRect, CGRect relativeRectangle);
    }

    /*
    // @interface MBDotsSubview : MBSubview <MBPointDetectorSubview>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    [DisableDefaultCtor]
    interface MBDotsSubview : IMBPointDetectorSubview
    {
        // @property (nonatomic, strong) CAShapeLayer * _Nonnull dotsLayer;
        [Export("dotsLayer", ArgumentSemantic.Strong)]
        CAShapeLayer DotsLayer { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull dotsColor;
        [Export("dotsColor", ArgumentSemantic.Strong)]
        UIColor DotsColor { get; set; }

        // @property (assign, nonatomic) CGFloat dotsStrokeWidth;
        [Export("dotsStrokeWidth")]
        nfloat DotsStrokeWidth { get; set; }

        // @property (assign, nonatomic) CGFloat dotsRadius;
        [Export("dotsRadius")]
        nfloat DotsRadius { get; set; }

        // @property (assign, nonatomic) CGFloat animationDuration;
        [Export("animationDuration")]
        nfloat AnimationDuration { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // -(instancetype _Nonnull)initWithCoder:(NSCoder * _Nonnull)aDecoder;
        [Export("initWithCoder:")]
        IntPtr Constructor(NSCoder aDecoder);
    }
    */

    // @interface MBDotsResultSubview : MBSubview <MBPointDetectorSubview>
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    interface MBDotsResultSubview : IMBPointDetectorSubview
    {
        // @property (nonatomic, strong) UIColor * _Nonnull foregroundColor;
        [Export("foregroundColor", ArgumentSemantic.Strong)]
        UIColor ForegroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull tintColor;
        [Export("tintColor", ArgumentSemantic.Strong)]
        UIColor TintColor { get; set; }

        // @property (assign, nonatomic) BOOL shouldIgnoreFastResults;
        [Export("shouldIgnoreFastResults")]
        bool ShouldIgnoreFastResults { get; set; }

        // @property (assign, nonatomic) CGFloat charFadeInDuration;
        [Export("charFadeInDuration")]
        nfloat CharFadeInDuration { get; set; }

        // @property (assign, nonatomic) NSUInteger dotCount;
        [Export("dotCount")]
        nuint DotCount { get; set; }
    }

    // @interface MBTapToFocusSubview : MBSubview
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    interface MBTapToFocusSubview
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)willFocusAtPoint:(CGPoint)point;
        [Export("willFocusAtPoint:")]
        void WillFocusAtPoint(CGPoint point);
    }

    // @protocol MBResultSubview <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBResultSubview
    {
        // @required -(void)scanningFinishedWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("scanningFinishedWithState:")]
        void ScanningFinishedWithState(MBRecognizerResultState state);
    }

    // @interface MBGlareStatusSubview : MBSubview
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(MBSubview))]
    [DisableDefaultCtor]
    interface MBGlareStatusSubview
    {
        // @property (nonatomic) UILabel * _Nonnull label;
        [Export("label", ArgumentSemantic.Assign)]
        UILabel Label { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)glareDetectionFinishedWithResult:(BOOL)glareFound;
        [Export("glareDetectionFinishedWithResult:")]
        void GlareDetectionFinishedWithResult(bool glareFound);
    }

    /*
    // @protocol MBLoggerDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MBLoggerDelegate
    {
        // @optional -(void)log:(MBLogLevel)level message:(const char *)message;
        [Export("log:message:")]
        unsafe void Message(MBLogLevel level, sbyte* message);

        // @optional -(void)log:(MBLogLevel)level format:(const char *)format arguments:(const char *)arguments;
        [Export("log:format:arguments:")]
        unsafe void Format(MBLogLevel level, sbyte* format, sbyte* arguments);
    }
    */

    // @interface MBLogger : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    interface MBLogger
    {
        /*
        [Wrap("WeakDelegate")]
        MBLoggerDelegate Delegate { get; set; }
        */

        // @property (nonatomic) id<MBLoggerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype)sharedInstance __attribute__((swift_name("shared()")));
        [Static]
        [Export("sharedInstance")]
        MBLogger SharedInstance();

        // -(void)disableMicroblinkLogging;
        [Export("disableMicroblinkLogging")]
        void DisableMicroblinkLogging();
    }

    // @interface MBBlinkIdOverlayTheme : NSObject
    [Introduced(PlatformName.iOS, 13, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBBlinkIdOverlayTheme
    {
        // +(instancetype _Nonnull)sharedInstance __attribute__((swift_name("shared()")));
        [Static]
        [Export("sharedInstance")]
        MBBlinkIdOverlayTheme SharedInstance();

        // @property (nonatomic, strong) UIFont * _Nonnull instructionsFont;
        [Export("instructionsFont", ArgumentSemantic.Strong)]
        UIFont InstructionsFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull instructionsTextColor;
        [Export("instructionsTextColor", ArgumentSemantic.Strong)]
        UIColor InstructionsTextColor { get; set; }

        // @property (assign, nonatomic) CGFloat instructionsCornerRadius;
        [Export("instructionsCornerRadius")]
        nfloat InstructionsCornerRadius { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull flashlightWarningFont;
        [Export("flashlightWarningFont", ArgumentSemantic.Strong)]
        UIFont FlashlightWarningFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull flashlightWarningBackgroundColor;
        [Export("flashlightWarningBackgroundColor", ArgumentSemantic.Strong)]
        UIColor FlashlightWarningBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull flashlightWarningTextColor;
        [Export("flashlightWarningTextColor", ArgumentSemantic.Strong)]
        UIColor FlashlightWarningTextColor { get; set; }

        // @property (assign, nonatomic) CGFloat flashlightWarningCornerRadius;
        [Export("flashlightWarningCornerRadius")]
        nfloat FlashlightWarningCornerRadius { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull frontCardImage;
        [Export("frontCardImage", ArgumentSemantic.Strong)]
        UIImage FrontCardImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull backCardImage;
        [Export("backCardImage", ArgumentSemantic.Strong)]
        UIImage BackCardImage { get; set; }

        // @property (nonatomic) UIColor * _Nonnull tooltipBackgroundColor;
        [Export("tooltipBackgroundColor", ArgumentSemantic.Assign)]
        UIColor TooltipBackgroundColor { get; set; }

        // @property (nonatomic) UIColor * _Nonnull tooltipTextColor;
        [Export("tooltipTextColor", ArgumentSemantic.Assign)]
        UIColor TooltipTextColor { get; set; }

        // @property (nonatomic) CGFloat tooltipCornerRadius;
        [Export("tooltipCornerRadius")]
        nfloat TooltipCornerRadius { get; set; }

        // @property (nonatomic) UIColor * _Nonnull onboardingAlertViewTitleTextColor;
        [Export("onboardingAlertViewTitleTextColor", ArgumentSemantic.Assign)]
        UIColor OnboardingAlertViewTitleTextColor { get; set; }

        // @property (nonatomic) UIFont * _Nonnull onboardingAlertViewTitleFont;
        [Export("onboardingAlertViewTitleFont", ArgumentSemantic.Assign)]
        UIFont OnboardingAlertViewTitleFont { get; set; }

        // @property (nonatomic) UIColor * _Nonnull onboardingAlertViewMessageTextColor;
        [Export("onboardingAlertViewMessageTextColor", ArgumentSemantic.Assign)]
        UIColor OnboardingAlertViewMessageTextColor { get; set; }

        // @property (nonatomic) UIFont * _Nonnull onboardingAlertViewMessageFont;
        [Export("onboardingAlertViewMessageFont", ArgumentSemantic.Assign)]
        UIFont OnboardingAlertViewMessageFont { get; set; }

        // @property (nonatomic) UIColor * _Nonnull onboardingAlertViewDoneButtonTextColor;
        [Export("onboardingAlertViewDoneButtonTextColor", ArgumentSemantic.Assign)]
        UIColor OnboardingAlertViewDoneButtonTextColor { get; set; }

        // @property (nonatomic) UIFont * _Nonnull onboardingAlertViewDoneButtonFont;
        [Export("onboardingAlertViewDoneButtonFont", ArgumentSemantic.Assign)]
        UIFont OnboardingAlertViewDoneButtonFont { get; set; }

        // @property (nonatomic) UIColor * _Nonnull tutorialViewTitleTextColor;
        [Export("tutorialViewTitleTextColor", ArgumentSemantic.Assign)]
        UIColor TutorialViewTitleTextColor { get; set; }

        // @property (nonatomic) UIFont * _Nonnull tutorialViewTitleFont;
        [Export("tutorialViewTitleFont", ArgumentSemantic.Assign)]
        UIFont TutorialViewTitleFont { get; set; }

        // @property (nonatomic) UIColor * _Nonnull tutorialViewMessageTextColor;
        [Export("tutorialViewMessageTextColor", ArgumentSemantic.Assign)]
        UIColor TutorialViewMessageTextColor { get; set; }

        // @property (nonatomic) UIFont * _Nonnull tutorialViewMessageFont;
        [Export("tutorialViewMessageFont", ArgumentSemantic.Assign)]
        UIFont TutorialViewMessageFont { get; set; }

        // @property (nonatomic) UIColor * _Nonnull tutorialViewActionButtonsTextColor;
        [Export("tutorialViewActionButtonsTextColor", ArgumentSemantic.Assign)]
        UIColor TutorialViewActionButtonsTextColor { get; set; }

        // @property (nonatomic) UIFont * _Nonnull tutorialViewActionButtonNextFont;
        [Export("tutorialViewActionButtonNextFont", ArgumentSemantic.Assign)]
        UIFont TutorialViewActionButtonNextFont { get; set; }

        // @property (nonatomic) UIFont * _Nonnull tutorialViewActionButtonCloseFont;
        [Export("tutorialViewActionButtonCloseFont", ArgumentSemantic.Assign)]
        UIFont TutorialViewActionButtonCloseFont { get; set; }

        // @property (nonatomic) UIColor * _Nonnull tutorialViewPageControlColor;
        [Export("tutorialViewPageControlColor", ArgumentSemantic.Assign)]
        UIColor TutorialViewPageControlColor { get; set; }

        // @property (nonatomic) UIImage * _Nonnull helpButtonImage;
        [Export("helpButtonImage", ArgumentSemantic.Assign)]
        UIImage HelpButtonImage { get; set; }

        // @property (nonatomic) UIImage * _Nonnull helpButtonDarkImage;
        [Export("helpButtonDarkImage", ArgumentSemantic.Assign)]
        UIImage HelpButtonDarkImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable defaultReticleImage;
        [NullAllowed, Export("defaultReticleImage", ArgumentSemantic.Strong)]
        UIImage DefaultReticleImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull successScanningImage;
        [Export("successScanningImage", ArgumentSemantic.Strong)]
        UIImage SuccessScanningImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable errorReticleImage;
        [NullAllowed, Export("errorReticleImage", ArgumentSemantic.Strong)]
        UIImage ErrorReticleImage { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull reticleColor;
        [Export("reticleColor", ArgumentSemantic.Strong)]
        UIColor ReticleColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull reticleDefaultColor;
        [Export("reticleDefaultColor", ArgumentSemantic.Strong)]
        UIColor ReticleDefaultColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull reticleErrorColor;
        [Export("reticleErrorColor", ArgumentSemantic.Strong)]
        UIColor ReticleErrorColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull successFlashColor;
        [Export("successFlashColor", ArgumentSemantic.Strong)]
        UIColor SuccessFlashColor { get; set; }
    }
}
