import Foundation
import UIKit
import SwiftUI
import BlinkID
import BlinkIDUX

/// A scanned date. Components are 0 when the SDK did not extract them.
@objc(OmnBlinkIDDate)
public final class OmnBlinkIDDate: NSObject {
    @objc public let day: Int
    @objc public let month: Int
    @objc public let year: Int

    init(day: Int, month: Int, year: Int) {
        self.day = day
        self.month = month
        self.year = year
    }

    static func from(_ result: DateResult<BlinkIDSDK.StringResult>?) -> OmnBlinkIDDate? {
        guard let result, let d = result.day, let m = result.month, let y = result.year else { return nil }
        return OmnBlinkIDDate(day: d, month: m, year: y)
    }
}

/// Flattened scan result. Mirrors the fields the shared MAUI layer consumes.
@objc(OmnBlinkIDResult)
public final class OmnBlinkIDResult: NSObject {
    @objc public var firstName: String?
    @objc public var lastName: String?
    @objc public var fullName: String?
    @objc public var address: String?
    @objc public var documentNumber: String?
    @objc public var fathersName: String?
    @objc public var mothersName: String?
    @objc public var sex: String?
    @objc public var localizedName: String?
    @objc public var additionalNameInformation: String?
    @objc public var additionalAddressInformation: String?
    @objc public var additionalOptionalAddressInformation: String?
    @objc public var placeOfBirth: String?
    @objc public var nationality: String?
    @objc public var race: String?
    @objc public var religion: String?
    @objc public var profession: String?
    @objc public var maritalStatus: String?
    @objc public var employer: String?
    @objc public var personalIdNumber: String?
    @objc public var documentAdditionalNumber: String?
    @objc public var documentOptionalAdditionalNumber: String?
    @objc public var issuingAuthority: String?
    @objc public var residentialStatus: String?
    @objc public var documentSubtype: String?
    @objc public var sponsor: String?
    @objc public var bloodType: String?

    @objc public var dateOfBirth: OmnBlinkIDDate?
    @objc public var dateOfIssue: OmnBlinkIDDate?
    @objc public var dateOfExpiry: OmnBlinkIDDate?

    @objc public var faceImage: UIImage?
    @objc public var signatureImage: UIImage?
    @objc public var frontImage: UIImage?
    @objc public var backImage: UIImage?

    convenience init(_ r: BlinkIDScanningResult) {
        self.init()
        firstName = r.firstName?.value
        lastName = r.lastName?.value
        fullName = r.fullName?.value
        address = r.address?.value
        documentNumber = r.documentNumber?.value
        fathersName = r.fathersName?.value
        mothersName = r.mothersName?.value
        sex = r.sex?.value
        localizedName = r.localizedName?.value
        additionalNameInformation = r.additionalNameInformation?.value
        additionalAddressInformation = r.additionalAddressInformation?.value
        additionalOptionalAddressInformation = r.additionalOptionalAddressInformation?.value
        placeOfBirth = r.placeOfBirth?.value
        nationality = r.nationality?.value
        race = r.race?.value
        religion = r.religion?.value
        profession = r.profession?.value
        maritalStatus = r.maritalStatus?.value
        employer = r.employer?.value
        personalIdNumber = r.personalIdNumber?.value
        documentAdditionalNumber = r.documentAdditionalNumber?.value
        documentOptionalAdditionalNumber = r.documentOptionalAdditionalNumber?.value
        issuingAuthority = r.issuingAuthority?.value
        residentialStatus = r.residentialStatus?.value
        documentSubtype = r.documentSubtype?.value
        sponsor = r.sponsor?.value
        bloodType = r.bloodType?.value

        dateOfBirth = OmnBlinkIDDate.from(r.dateOfBirth)
        dateOfIssue = OmnBlinkIDDate.from(r.dateOfIssue)
        dateOfExpiry = OmnBlinkIDDate.from(r.dateOfExpiry)

        faceImage = r.getFaceImage()?.uiImage
        signatureImage = r.getSignatureImage()?.uiImage
        frontImage = r.getDocumentImage(scanningSide: .first)?.uiImage
        backImage = r.getDocumentImage(scanningSide: .second)?.uiImage
    }
}

@objc(OmnBlinkIDErrorCode)
public enum OmnBlinkIDErrorCode: Int {
    case notInitialized = 1
    case sdkInitFailed = 2
    case analyzerFailed = 3
}

/// ObjC-visible entry point over the pure-Swift BlinkID v8 SDK.
///
/// BlinkID 8 exposes no Objective-C surface, so .NET cannot bind it directly.
/// This shim is the bindable seam: it owns the SDK handle and hosts the
/// SwiftUI scanning view inside a UIHostingController.
@objc(OmnBlinkIDScanner)
public final class OmnBlinkIDScanner: NSObject {

    private static var sdk: BlinkIDSdk?

    private static func error(_ code: OmnBlinkIDErrorCode, _ message: String) -> NSError {
        NSError(domain: "com.omnicasa.blinkid",
                code: code.rawValue,
                userInfo: [NSLocalizedDescriptionKey: message])
    }

    /// Initializes the SDK. Must succeed before `present` is called.
    @objc public static func initialize(licenseKey: String,
                                        completion: @escaping (NSError?) -> Void) {
        Task {
            do {
                var settings = BlinkIDSdkSettings(licenseKey: licenseKey)
                settings.downloadResources = true
                let created = try await BlinkIDSdk.createBlinkIDSdk(withSettings: settings)
                await MainActor.run {
                    sdk = created
                    completion(nil)
                }
            } catch {
                await MainActor.run {
                    completion(self.error(.sdkInitFailed, "\(error)"))
                }
            }
        }
    }

    /// Presents the scanning UI. `completion` receives nil/nil when the user cancels.
    @objc public static func present(from presenter: UIViewController,
                                     completion: @escaping (OmnBlinkIDResult?, NSError?) -> Void) {
        guard let sdk else {
            completion(nil, error(.notInitialized, "Call initialize(licenseKey:) first"))
            return
        }

        Task { @MainActor in
            do {
                let analyzer = try await BlinkIDAnalyzer(sdk: sdk)

                var host: UIViewController?
                let finish: (OmnBlinkIDResult?, NSError?) -> Void = { result, err in
                    host?.dismiss(animated: true) {
                        completion(result, err)
                    }
                    host = nil
                }

                let view = BlinkIDUXView(analyzer: analyzer) { state in
                    guard let scanned = state.scanningResult else {
                        finish(nil, nil)   // cancelled or interrupted
                        return
                    }
                    finish(OmnBlinkIDResult(scanned), nil)
                }

                let controller = UIHostingController(rootView: view)
                controller.modalPresentationStyle = .fullScreen
                host = controller
                presenter.present(controller, animated: true)
            } catch {
                completion(nil, self.error(.analyzerFailed, "\(error)"))
            }
        }
    }
}
