﻿using System;
using System.Runtime.InteropServices;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace Omnicasa.Mobile.BlinkID.iOS
{
    /*
    static class CFunctions
    {
        // NSString * MB_LOCALIZED_DEFAULT_STRING (NSString *key);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern NSString MB_LOCALIZED_DEFAULT_STRING(NSString key);

        // NSString * MB_LOCALIZED_FOR_LANGUAGE (NSString *key, NSString *language);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern NSString MB_LOCALIZED_FOR_LANGUAGE(NSString key, NSString language);

        // NSString * MB_LOCALIZED (NSString *key);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern NSString MB_LOCALIZED(NSString key);

        // MBImageExtensionFactors MBMakeImageExtensionFactors (CGFloat top, CGFloat right, CGFloat bottom, CGFloat left) __attribute__((always_inline));
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern MBImageExtensionFactors MBMakeImageExtensionFactors(nfloat top, nfloat right, nfloat bottom, nfloat left);

        // extern CGDelta CGDeltaMake (CGFloat deltaX, CGFloat deltaY);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGDelta CGDeltaMake(nfloat deltaX, nfloat deltaY);

        // extern CGPoint CGPointWithDelta (CGPoint point, CGDelta delta);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGPointWithDelta(CGPoint point, CGDelta delta);

        // extern CGFloat CGPointDistance (CGPoint p1, CGPoint p2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern nfloat CGPointDistance(CGPoint p1, CGPoint p2);

        // extern CGPoint CGPointAlongLine (CGLine line, CGFloat distance);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGPointAlongLine(CGLine line, nfloat distance);

        // extern CGPoint CGPointRotatedAroundPoint (CGPoint point, CGPoint pivot, CGFloat degrees);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGPointRotatedAroundPoint(CGPoint point, CGPoint pivot, nfloat degrees);

        // extern CGLine CGLineMake (CGPoint point1, CGPoint point2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGLine CGLineMake(CGPoint point1, CGPoint point2);

        // extern _Bool CGLineEqualToLine (CGLine line1, CGLine line2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern bool CGLineEqualToLine(CGLine line1, CGLine line2);

        // extern CGPoint CGLineMidPoint (CGLine line);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGLineMidPoint(CGLine line);

        // extern CGFloat CGLineDirection (CGLine line);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern nfloat CGLineDirection(CGLine line);

        // extern CGFloat CGLinesAngle (CGLine line1, CGLine line2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern nfloat CGLinesAngle(CGLine line1, CGLine line2);

        // extern CGPoint CGLinesIntersectAtPoint (CGLine line1, CGLine line2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGLinesIntersectAtPoint(CGLine line1, CGLine line2);

        // extern CGFloat CGLineLength (CGLine line);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern nfloat CGLineLength(CGLine line);

        // extern CGLine CGLineScale (CGLine line, CGFloat scale);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGLine CGLineScale(CGLine line, nfloat scale);

        // extern CGLine CGLineTranslate (CGLine line, CGDelta delta);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGLine CGLineTranslate(CGLine line, CGDelta delta);

        // extern CGLine CGLineScaleOnMidPoint (CGLine line, CGFloat scale);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGLine CGLineScaleOnMidPoint(CGLine line, nfloat scale);

        // extern CGDelta CGLineDelta (CGLine line);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGDelta CGLineDelta(CGLine line);

        // extern _Bool CGLinesAreParallel (CGLine line1, CGLine line2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern bool CGLinesAreParallel(CGLine line1, CGLine line2);

        // extern CGPoint CGRectTopLeftPoint (CGRect rect);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGRectTopLeftPoint(CGRect rect);

        // extern CGPoint CGRectTopRightPoint (CGRect rect);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGRectTopRightPoint(CGRect rect);

        // extern CGPoint CGRectBottomLeftPoint (CGRect rect);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGRectBottomLeftPoint(CGRect rect);

        // extern CGPoint CGRectBottomRightPoint (CGRect rect);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGRectBottomRightPoint(CGRect rect);

        // extern CGRect CGRectResize (CGRect rect, CGSize newSize);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGRect CGRectResize(CGRect rect, CGSize newSize);

        // extern CGRect CGRectInsetEdge (CGRect rect, CGRectEdge edge, CGFloat amount);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGRect CGRectInsetEdge(CGRect rect, CGRectEdge edge, nfloat amount);

        // extern CGRect CGRectStackedWithinRectFromEdge (CGRect rect, CGSize size, int count, CGRectEdge edge, _Bool reverse);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGRect CGRectStackedWithinRectFromEdge(CGRect rect, CGSize size, int count, CGRectEdge edge, bool reverse);

        // extern CGPoint CGRectCenterPoint (CGRect rect);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGRectCenterPoint(CGRect rect);

        // extern void CGRectClosestTwoCornerPoints (CGRect rect, CGPoint point, CGPoint *point1, CGPoint *point2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern unsafe void CGRectClosestTwoCornerPoints(CGRect rect, CGPoint point, CGPoint* point1, CGPoint* point2);

        // extern CGPoint CGLineIntersectsRectAtPoint (CGRect rect, CGLine line);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGLineIntersectsRectAtPoint(CGRect rect, CGLine line);

        // extern CGPoint CGTransformedPointToDestination (CGPoint point, CGRect originalRect, CGRect destinationRect);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGPoint CGTransformedPointToDestination(CGPoint point, CGRect originalRect, CGRect destinationRect);

        // extern void CGControlPointsForArcBetweenPointsWithRadius (CGPoint startPoint, CGPoint endPoint, CGFloat radius, _Bool rightHandRule, CGPoint *controlPoint1, CGPoint *controlPoint2);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern unsafe void CGControlPointsForArcBetweenPointsWithRadius(CGPoint startPoint, CGPoint endPoint, nfloat radius, bool rightHandRule, CGPoint* controlPoint1, CGPoint* controlPoint2);

        // extern CGRect MBscanningRegionForFrameInBounds (CGRect frame, CGRect bounds) __attribute__((visibility("default")));
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern CGRect MBscanningRegionForFrameInBounds(CGRect frame, CGRect bounds);
    }
    */

    [Native]
    public enum MBCameraPreset : long
    {
        MBCameraPreset480p,
        MBCameraPreset720p,
        MBCameraPreset1080p,
        MBCameraPreset4K,
        Optimal,
        Max,
        Photo
    }

    [Native]
    public enum MBCameraType : long
    {
        Back,
        Front
    }

    [Native]
    public enum MBCameraAutofocusRestriction : long
    {
        None,
        Near,
        Far
    }

    [Native]
    public enum MBRecognizerResultState : long
    {
        Empty,
        Uncertain,
        Valid,
        StageValid
    }

    [Native]
    public enum MBAgeLimitStatus : long
    {
        NotAvailable,
        BelowAgeLimit,
        OverAgeLimit
    }

    [Native]
    public enum MBMrtdDocumentType : long
    {
        Unknown,
        IdentityCard,
        Passport,
        Visa,
        GreenCard,
        MysPassIMM13P,
        Dl,
        InternalTravelDocument,
        BorderCrossingCard
    }

    [Native]
    public enum MBBarcodeType : long
    {
        None = 0,
        TypeQR,
        TypeDataMatrix,
        TypeUPCE,
        TypeUPCA,
        TypeEAN8,
        TypeEAN13,
        TypeCode128,
        TypeCode39,
        TypeITF,
        TypeAztec,
        TypePdf417
    }

    [Native]
    public enum MBBarcodeElementKey : long
    {
        DocumentType = 0,
        StandardVersionNumber,
        CustomerFamilyName,
        CustomerFirstName,
        CustomerFullName,
        DateOfBirth,
        Sex,
        EyeColor,
        AddressStreet,
        AddressCity,
        AddressJurisdictionCode,
        AddressPostalCode,
        FullAddress,
        Height,
        HeightIn,
        HeightCm,
        CustomerMiddleName,
        HairColor,
        NameSuffix,
        AKAFullName,
        AKAFamilyName,
        AKAGivenName,
        AKASuffixName,
        WeightRange,
        WeightPounds,
        WeightKilograms,
        CustomerIdNumber,
        FamilyNameTruncation,
        FirstNameTruncation,
        MiddleNameTruncation,
        PlaceOfBirth,
        AddressStreet2,
        RaceEthnicity,
        NamePrefix,
        CountryIdentification,
        ResidenceStreetAddress,
        ResidenceStreetAddress2,
        ResidenceCity,
        ResidenceJurisdictionCode,
        ResidencePostalCode,
        ResidenceFullAddress,
        Under18,
        Under19,
        Under21,
        SocialSecurityNumber,
        AKASocialSecurityNumber,
        AKAMiddleName,
        AKAPrefixName,
        OrganDonor,
        Veteran,
        AKADateOfBirth,
        IssuerIdentificationNumber,
        DocumentExpirationDate,
        JurisdictionVersionNumber,
        JurisdictionVehicleClass,
        JurisdictionRestrictionCodes,
        JurisdictionEndorsementCodes,
        DocumentIssueDate,
        FederalCommercialVehicleCodes,
        IssuingJurisdiction,
        StandardVehicleClassification,
        IssuingJurisdictionName,
        StandardEndorsementCode,
        StandardRestrictionCode,
        JurisdictionVehicleClassificationDescription,
        JurisdictionEndorsmentCodeDescription,
        JurisdictionRestrictionCodeDescription,
        InventoryControlNumber,
        CardRevisionDate,
        DocumentDiscriminator,
        LimitedDurationDocument,
        AuditInformation,
        ComplianceType,
        IssueTimestamp,
        PermitExpirationDate,
        PermitIdentifier,
        PermitIssueDate,
        NumberOfDuplicates,
        HAZMATExpirationDate,
        MedicalIndicator,
        NonResident,
        UniqueCustomerId,
        DataDiscriminator,
        DocumentExpirationMonth,
        DocumentNonexpiring,
        SecurityVersion
    }

    [Native]
    public enum MBProcessingStatus : long
    {
        Success,
        DetectionFailed,
        ImagePreprocessingFailed,
        StabilityTestFailed,
        ScanningWrongSide,
        FieldIdentificationFailed,
        MandatoryFieldMissing,
        InvalidCharactersFound,
        ImageReturnFailed,
        BarcodeRecognitionFailed,
        MrzParsingFailed,
        ClassFiltered,
        UnsupportedClass,
        UnsupportedByLicense,
        AwaitingOtherSide,
        NotScanned,
        BarcodeDetectionFailed
    }

    [Native]
    public enum MBRecognitionMode : long
    {
        None,
        MrzId,
        MrzVisa,
        MrzPassport,
        PhotoId,
        FullRecognition,
        BarcodeId
    }

    [Native]
    public enum MBDataMatchState : long
    {
        NotPerformed = 0,
        Failed,
        Success
    }

    [Native]
    public enum MBVideoRotationAngle : long
    {
        LandscapeLeft,
        Portrait,
        LandscapeRight,
        PortraitUpsideDown
    }

    [Native]
    public enum MBProcessingOrientation : long
    {
        Up,
        Right,
        Down,
        Left
    }

    [Native]
    public enum MBAlphabetType : long
    {
        Latin,
        Arabic,
        Cyrillic
    }

    [Native]
    public enum MBSide : long
    {
        None = 0,
        Front,
        Back
    }

    [Native]
    public enum MBCountry : long
    {
        None = 0,
        Albania,
        Algeria,
        Argentina,
        Australia,
        Austria,
        Azerbaijan,
        Bahrain,
        Bangladesh,
        Belgium,
        BosniaAndHerzegovina,
        Brunei,
        Bulgaria,
        Cambodia,
        Canada,
        Chile,
        Colombia,
        CostaRica,
        Croatia,
        Cyprus,
        Czechia,
        Denmark,
        DominicanRepublic,
        Egypt,
        Estonia,
        Finland,
        France,
        Georgia,
        Germany,
        Ghana,
        Greece,
        Guatemala,
        HongKong,
        Hungary,
        India,
        Indonesia,
        Ireland,
        Israel,
        Italy,
        Jordan,
        Kazakhstan,
        Kenya,
        Kosovo,
        Kuwait,
        Latvia,
        Lithuania,
        Malaysia,
        Maldives,
        Malta,
        Mauritius,
        Mexico,
        Morocco,
        Netherlands,
        NewZealand,
        Nigeria,
        Pakistan,
        Panama,
        Paraguay,
        Philippines,
        Poland,
        Portugal,
        PuertoRico,
        Qatar,
        Romania,
        Russia,
        SaudiArabia,
        Serbia,
        Singapore,
        Slovakia,
        Slovenia,
        SouthAfrica,
        Spain,
        Sweden,
        Switzerland,
        Taiwan,
        Thailand,
        Tunisia,
        Turkey,
        Uae,
        Uganda,
        Uk,
        Ukraine,
        Usa,
        Vietnam,
        Brazil,
        Norway,
        Oman,
        Ecuador,
        ElSalvador,
        SriLanka,
        Peru,
        Uruguay,
        Bahamas,
        Bermuda,
        Bolivia,
        China,
        EuropeanUnion,
        Haiti,
        Honduras,
        Iceland,
        Japan,
        Luxembourg,
        Montenegro,
        Nicaragua,
        SouthKorea,
        Venezuela,
        Afghanistan,
        AlandIslands,
        AmericanSamoa,
        Andorra,
        Angola,
        Anguilla,
        Antarctica,
        AntiguaAndBarbuda,
        Armenia,
        Aruba,
        BailiwickOfGuernsey,
        BailiwickOfJersey,
        Barbados,
        Belarus,
        Belize,
        Benin,
        Bhutan,
        BonaireSaintEustatiusAndSaba,
        Botswana,
        BouvetIsland,
        BritishIndianOceanTerritory,
        BurkinaFaso,
        Burundi,
        Cameroon,
        CapeVerde,
        CaribbeanNetherlands,
        CaymanIslands,
        CentralAfricanRepublic,
        Chad,
        ChristmasIsland,
        CocosIslands,
        Comoros,
        Congo,
        CookIslands,
        Cuba,
        Curacao,
        DemocraticRepublicOfTheCongo,
        Djibouti,
        Dominica,
        EastTimor,
        EquatorialGuinea,
        Eritrea,
        Ethiopia,
        FalklandIslands,
        FaroeIslands,
        FederatedStatesOfMicronesia,
        Fiji,
        FrenchGuiana,
        FrenchPolynesia,
        FrenchSouthernTerritories,
        Gabon,
        Gambia,
        Gibraltar,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guinea,
        GuineaBissau,
        Guyana,
        HeardIslandAndMcdonaldIslands,
        Iran,
        Iraq,
        IsleOfMan,
        IvoryCoast,
        Jamaica,
        Kiribati,
        Kyrgyzstan,
        Laos,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Macau,
        Madagascar,
        Malawi,
        Mali,
        MarshallIslands,
        Martinique,
        Mauritania,
        Mayotte,
        Moldova,
        Monaco,
        Mongolia,
        Montserrat,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        NewCaledonia,
        Niger,
        Niue,
        NorfolkIsland,
        NorthernCyprus,
        NorthernMarianaIslands,
        NorthKorea,
        NorthMacedonia,
        Palau,
        Palestine,
        PapuaNewGuinea,
        Pitcairn,
        Reunion,
        Rwanda,
        SaintBarthelemy,
        SaintHelenaAscensionAndTristianDaCunha,
        SaintKittsAndNevis,
        SaintLucia,
        SaintMartin,
        SaintPierreAndMiquelon,
        SaintVincentAndTheGrenadines,
        Samoa,
        SanMarino,
        SaoTomeAndPrincipe,
        Senegal,
        Seychelles,
        SierraLeone,
        SintMaarten,
        SolomonIslands,
        Somalia,
        SouthGeorgiaAndTheSouthSandwichIslands,
        SouthSudan,
        Sudan,
        Suriname,
        SvalbardAndJanMayen,
        Eswatini,
        Syria,
        Tajikistan,
        Tanzania,
        Togo,
        Tokelau,
        Tonga,
        TrinidadAndTobago,
        Turkmenistan,
        TurksAndCaicosIslands,
        Tuvalu,
        UnitedStatesMinorOutlyingIslands,
        Uzbekistan,
        Vanuatu,
        VaticanCity,
        VirginIslandsBritish,
        VirginIslandsUs,
        WallisAndFutuna,
        WesternSahara,
        Yemen,
        Yugoslavia,
        Zambia,
        Zimbabwe,
        SchengenArea
    }

    [Native]
    public enum MBRegion : long
    {
        None = 0,
        Alabama,
        Alaska,
        Alberta,
        Arizona,
        Arkansas,
        AustralianCapitalTerritory,
        BritishColumbia,
        California,
        Colorado,
        Connecticut,
        Delaware,
        DistrictOfColumbia,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Manitoba,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        NewBrunswick,
        NewHampshire,
        NewJersey,
        NewMexico,
        NewSouthWales,
        NewYork,
        NorthernTerritory,
        NorthCarolina,
        NorthDakota,
        NovaScotia,
        Ohio,
        Oklahoma,
        Ontario,
        Oregon,
        Pennsylvania,
        Quebec,
        Queensland,
        RhodeIsland,
        Saskatchewan,
        SouthAustralia,
        SouthCarolina,
        SouthDakota,
        Tasmania,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Victoria,
        Virginia,
        Washington,
        WesternAustralia,
        WestVirginia,
        Wisconsin,
        Wyoming,
        Yukon,
        CiudadDeMexico,
        Jalisco,
        NewfoundlandAndLabrador,
        NuevoLeon,
        BajaCalifornia,
        Chihuahua,
        Guanajuato,
        Guerrero,
        Mexico,
        Michoacan,
        NewYorkCity,
        Tamaulipas,
        Veracruz,
        Chiapas,
        Coahuila,
        Durango,
        GuerreroCocula,
        GuerreroJuchitan,
        GuerreroTepecoacuilco,
        GuerreroTlacoapa,
        Gujarat,
        Hidalgo,
        Karnataka,
        Kerala,
        KhyberPakhtunkhwa,
        MadhyaPradesh,
        Maharashtra,
        Morelos,
        Nayarit,
        Oaxaca,
        Puebla,
        Punjab,
        Queretaro,
        SanLuisPotosi,
        Sinaloa,
        Sonora,
        Tabasco,
        TamilNadu,
        Yucatan,
        Zacatecas,
        Aguascalientes,
        BajaCaliforniaSur,
        Campeche,
        Colima,
        QuintanaRooBenitoJuarez,
        QuintanaRoo,
        QuintanaRooSolidaridad,
        Tlaxcala,
        QuintanaRooCozumel,
        SaoPaolo,
        RioDeJaneiro,
        RioGrandeDoSul,
        NorthwestTerritories,
        Nunavut,
        PrinceEdwardIsland,
        DistritoFederal,
        Maranhao,
        MatoGrosso,
        MinasGerais,
        Para,
        Parana,
        Pernambuco,
        SantaCatarina,
        AndhraPradesh,
        Ceara,
        Goias,
        GuerreroAcapulcoDeJuarez,
        Haryana,
        Sergipe
    }

    [Native]
    public enum MBType : long
    {
        None = 0,
        ConsularId,
        Dl,
        DlPublicServicesCard,
        EmploymentPass,
        FinCard,
        Id,
        MultipurposeId,
        MyKad,
        MyKid,
        MyPR,
        MyTentera,
        PanCard,
        ProfessionalId,
        PublicServicesCard,
        ResidencePermit,
        ResidentId,
        TemporaryResidencePermit,
        VoterId,
        WorkPermit,
        iKad,
        MilitaryId,
        MyKas,
        SocialSecurityCard,
        HealthInsuranceCard,
        Passport,
        SPass,
        AddressCard,
        AlienId,
        AlienPassport,
        GreenCard,
        MinorsId,
        PostalId,
        ProfessionalDl,
        TaxId,
        WeaponPermit,
        Visa,
        BorderCrossingCard,
        DriverCard,
        GlobalEntryCard,
        Mypolis,
        NexusCard,
        PassportCard,
        ProofOfAgeCard,
        RefugeeId,
        TribalId,
        VeteranId,
        CitizenshipCertificate,
        MyNumberCard,
        ConsularPassport,
        MinorsPassport,
        MinorsPublicServicesCard,
        DrivingPrivilegeCard,
        AsylumRequest,
        DriverQualificationCard,
        ProvisionalDl,
        RefugeePassport,
        SpecialId,
        UniformedServicesId,
        ImmigrantVisa,
        ConsularVoterId,
        TwicCard,
        ExitEntryPermit,
        MainlandTravelPermitTaiwan,
        NbiClearance,
        ProofOfRegistration,
        TemporaryProtectionPermit
    }

    [Native]
    public enum MBDocumentImageColorStatus : long
    {
        NotAvailable = 0,
        BlackAndWhite,
        Color
    }

    [Native]
    public enum MBImageAnalysisDetectionStatus : long
    {
        NotAvailable = 0,
        NotDetected,
        Detected
    }

    [Native]
    public enum MBCardOrientation : long
    {
        Horizontal,
        Vertical,
        NotAvailable
    }

    [Native]
    public enum MBRotation : long
    {
        Zero,
        Clockwise90,
        CounterClockwise90,
        UpsideDown,
        None
    }

    [Native]
    public enum MBDataMatchField : long
    {
        ateOfBirth = 0,
        ateOfExpiry,
        ocumentNumber
    }

    [Native]
    public enum MBLicenseError : long
    {
        NetworkRequired,
        UnableToDoRemoteLicenceCheck,
        LicenseIsLocked,
        LicenseCheckFailed,
        InvalidLicense,
        PermissionExpired,
        PayloadCorrupted,
        PayloadSignatureVerificationFailed,
        IncorrectTokenState
    }

    [Native]
    public enum MBOcrFont : long
    {
        AkzidenzGrotesk,
        Arial,
        ArialBlack,
        Arnhem,
        AvantGarde,
        Bembo,
        Bodoni,
        Calibri,
        CalibriBold,
        Chainprinter,
        ComicSans,
        ConcertoRoundedSg,
        Courier,
        CourierBold,
        CourierMediumBold,
        CourierNewBold,
        CourierNewCe,
        CourierCondensed,
        DejavuSansMono,
        Din,
        EuropaGroteskNo2SbBold,
        Eurostile,
        F25BankPrinterBold,
        FranklinGothic,
        Frutiger,
        Futura,
        FuturaBold,
        Garamond,
        Georgia,
        GillSans,
        Handwritten,
        Helvetica,
        HelveticaBold,
        HelveticaCondensedLight,
        Hypermarket,
        Interstate,
        LatinModern,
        LatinModernItalic,
        LetterGothic,
        Lucida,
        LucidaSans,
        Matrix,
        Meta,
        Minion,
        Ocra,
        Ocrb,
        Officina,
        Optima,
        Printf,
        Rockwell,
        RotisSansSerif,
        RotisSerif,
        Sabon,
        Stone,
        SvBasicManual,
        Tahoma,
        TahomaBold,
        TexGyreTermes,
        TexGyreTermesItalic,
        TheSansMonoCondensedBlack,
        Thesis,
        TicketDeCaisse,
        TimesNewRoman,
        Trajan,
        Trinite,
        Univers,
        Verdana,
        Voltaire,
        Walbaum,
        EuropaGroSb,
        EuropaGroSbLight,
        AntonioRegular,
        CorporateLight,
        Micr,
        ArabicNile,
        Unknown,
        XitsMath,
        Any,
        UnknownMath,
        UkdlLight,
        Count,
        FeSchrift
    }

    [Native]
    public enum MBDocumentFaceDetectorType : long
    {
        Td1 = 0,
        Td2,
        PassportsAndVisas
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MBImageExtensionFactors
    {
        public nfloat top;

        public nfloat right;

        public nfloat bottom;

        public nfloat left;
    }

    [Native]
    public enum MBAnonymizationMode : long
    {
        None = 0,
        ImageOnly,
        ResultFieldsOnly,
        FullResult
    }

    [Native]
    public enum MBStrictnessLevel : long
    {
        Strict = 0,
        Normal,
        Relaxed
    }

    [Native]
    public enum MBIdBarcodeDocumentType : long
    {
        None = 0,
        AAMVACompliant,
        ArgentinaID,
        ArgentinaAlienID,
        ArgentinaDL,
        ColombiaID,
        ColombiaDL,
        NigeriaVoterID,
        NigeriaDL,
        PanamaID,
        SouthAfricaID
    }

    [Native]
    public enum MBMrtdSpecificationPreset : long
    {
        MBMrtdSpecificationTd1,
        MBMrtdSpecificationTd2,
        MBMrtdSpecificationTd3
    }

    [Native]
    public enum MBUsdlKeys : long
    {
        DocumentType,
        StandardVersionNumber,
        CustomerFamilyName,
        CustomerFirstName,
        CustomerFullName,
        DateOfBirth,
        Sex,
        EyeColor,
        AddressStreet,
        AddressCity,
        AddressJurisdictionCode,
        AddressPostalCode,
        FullAddress,
        Height,
        HeightIn,
        HeightCm,
        CustomerMiddleName,
        HairColor,
        NameSuffix,
        AKAFullName,
        AKAFamilyName,
        AKAGivenName,
        AKASuffixName,
        WeightRange,
        WeightPounds,
        WeightKilograms,
        CustomerIdNumber,
        FamilyNameTruncation,
        FirstNameTruncation,
        MiddleNameTruncation,
        PlaceOfBirth,
        AddressStreet2,
        RaceEthnicity,
        NamePrefix,
        CountryIdentification,
        ResidenceStreetAddress,
        ResidenceStreetAddress2,
        ResidenceCity,
        ResidenceJurisdictionCode,
        ResidencePostalCode,
        ResidenceFullAddress,
        Under18,
        Under19,
        Under21,
        SocialSecurityNumber,
        AKASocialSecurityNumber,
        AKAMiddleName,
        AKAPrefixName,
        OrganDonor,
        Veteran,
        AKADateOfBirth,
        IssuerIdentificationNumber,
        DocumentExpirationDate,
        JurisdictionVersionNumber,
        JurisdictionVehicleClass,
        JurisdictionRestrictionCodes,
        JurisdictionEndorsementCodes,
        DocumentIssueDate,
        FederalCommercialVehicleCodes,
        IssuingJurisdiction,
        StandardVehicleClassification,
        IssuingJurisdictionName,
        StandardEndorsementCode,
        StandardRestrictionCode,
        JurisdictionVehicleClassificationDescription,
        JurisdictionEndorsmentCodeDescription,
        JurisdictionRestrictionCodeDescription,
        InventoryControlNumber,
        CardRevisionDate,
        DocumentDiscriminator,
        LimitedDurationDocument,
        AuditInformation,
        ComplianceType,
        IssueTimestamp,
        PermitExpirationDate,
        PermitIdentifier,
        PermitIssueDate,
        NumberOfDuplicates,
        HAZMATExpirationDate,
        MedicalIndicator,
        NonResident,
        UniqueCustomerId,
        DataDiscriminator,
        DocumentExpirationMonth,
        DocumentNonexpiring,
        SecurityVersion
    }

    [Native]
    public enum MBProcessorResultState : long
    {
        Empty,
        Uncertain,
        Valid
    }

    [Flags]
    [Native]
    public enum MBDetectionStatus : long
    {
        Failed,
        Success,
        CameraTooFar,
        CameraTooClose,
        CameraAngleTooSteep,
        DocumentTooCloseToCameraEdge,
        DocumentPartiallyVisible,
        FallbackSuccess
    }

    [Native]
    public enum MBFieldType : long
    {
        AdditionalAddressInformation,
        AdditionalNameInformation,
        AdditionalOptionalAddressInformation,
        AdditionalPersonalIdNumber,
        Address,
        ClassEffectiveDate,
        ClassExpiryDate,
        Conditions,
        DateOfBirth,
        DateOfExpiry,
        DateOfIssue,
        DocumentAdditionalNumber,
        DocumentOptionalAdditionalNumber,
        DocumentNumber,
        Employer,
        Endorsements,
        FathersName,
        FirstName,
        FullName,
        IssuingAuthority,
        LastName,
        LicenceType,
        LocalizedName,
        MaritalStatus,
        MothersName,
        Mrz,
        Nationality,
        PersonalIdNumber,
        PlaceOfBirth,
        Profession,
        Race,
        Religion,
        ResidentialStatus,
        Restrictions,
        Sex,
        VehicleClass,
        BloodType,
        DocumentSubtype,
        Sponsor
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CGLine
    {
        public CGPoint point1;

        public CGPoint point2;
    }

    [Native]
    public enum MBRecognitionDebugMode : long
    {
        Default,
        Test,
        DetectionTest
    }

    [Native]
    public enum MBFrameQualityEstimationMode : long
    {
        Default,
        On,
        Off
    }

    [Native]
    public enum MBLegacyDocumentVerificationHighResImageState : long
    {
        FrontSide,
        BackSideSide
    }

    [Native]
    public enum MBLogLevel : long
    {
        Error,
        Warning,
        Info,
        Debug,
        Verbose
    }
}
