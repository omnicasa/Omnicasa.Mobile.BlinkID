using Android.Content;
using Android.Widget;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using AndroidX.AppCompat.App;
using Com.Microblink.Blinkid.Core;
using Com.Microblink.Blinkid.Core.Result;
using Com.Microblink.Blinkid.Core.Session;
using Com.Microblink.Blinkid.UX.Contract;

namespace Omnicasa.Mobile.BlinkID.UX.Maui.Droid.Demo;

/// <summary>
/// Demo activity matching the official BlinkID Android Java sample pattern.
/// See: https://github.com/BlinkID/blinkid-android/blob/master/BlinkIDSample/java-sample-app
/// </summary>
[Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
public class MainActivity : AppCompatActivity, IActivityResultCallback
{
    private const string LICENSE_KEY =
        "sRwAAAAoY29tLmNvbXBhbnluYW1lLmJsaW5raWQudXgubWF1aS5kcm9pZC5kZW1vtUmyrJTVfMRz3FQnnFV8HMMIU/M4mwPvkZcpAoTa7YGIc0OlHkJ0NTdKuhW9/1n3p00OwI5LG9tlwzFdMZBqkpawbCr/MfRSqwvK+Ov0GCKsMZZC2L0FKlwPHqkYHVB4AUNWa4NPLDI26yzalFwUB3WaLNnpz/HuPnAeM+VPwBhE7E7S0P6YJB5x";
    private const string DroidLic = "sRwAAAATY29tLm9tbmljYXNhLm1vYmlsZWIBD4xeaH4PRjTgkGPcb9r31QSc35hNGegKgsEoRhc4c0FT1RXwrk2OWBo1jzWcdOOqB9jgYCoWxtBLHJTgV1bo77X8aAsEpC93GXnrybsMemrnRY886Cnf5RXtesCjLFq3SzDq6l7uLzNnDmfzSJf+HhLArsD/80fjh6G/O6cgYHzlPy5J94utkLBO3GCaGM1mQFb4";

    private ActivityResultLauncher? _scanLauncher;
    private TextView? _statusText;
    private Button? _scanButton;
    private TextView? _resultText;
    private ImageView? imgFace, imgSign, imgFront, imgBack;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);

        _statusText = FindViewById<TextView>(Resource.Id.statusText);
        _scanButton = FindViewById<Button>(Resource.Id.scanButton);
        _resultText = FindViewById<TextView>(Resource.Id.resultText);
        imgFace = FindViewById<ImageView>(Resource.Id.face);
        imgSign = FindViewById<ImageView>(Resource.Id.sign);
        imgFront = FindViewById<ImageView>(Resource.Id.front);
        imgBack = FindViewById<ImageView>(Resource.Id.back);

        // Register for activity result — equivalent to the official Java sample:
        //   registerForActivityResult(new MbBlinkIdScan(), result -> { ... });
        _scanLauncher = RegisterForActivityResult(
            new ActivityResultContracts.StartActivityForResult(), this);

        _scanButton!.Click += (_, _) => LaunchScan();
    }

    /// <summary>
    /// Launches the BlinkID scan activity — matching the official Java sample:
    ///   BlinkIdSdkSettings sdkSettings = new BlinkIdSdkSettings(licenseKey);
    ///   BlinkIdScanActivitySettings settings = new BlinkIdScanActivitySettings(sdkSettings);
    ///   resultLauncher.launch(settings);
    /// </summary>
    private void LaunchScan()
    {
        try
        {
                
            _statusText!.Text = "Launching scanner...";
            _resultText!.Text = "";

            var sdkSettings = new BlinkIdSdkSettings(DroidLic);
            var settings = new BlinkIdScanActivitySettings(sdkSettings, BuildSessionSettings());

            var contract = new MbBlinkIdScan();
            var intent = contract.CreateIntent(this, settings);
            _scanLauncher!.Launch(intent);
        }
        catch (Exception ex)
        {
            _statusText!.Text = $"Launch failed: {ex.Message}";
        }
    }

    /// <summary>
    /// Enables image return, which is off by default. v8 settings are immutable and split
    /// across scanner modules, so the tree has to be rebuilt with Copy rather than mutated.
    /// </summary>
    private static BlinkIdSessionSettings BuildSessionSettings()
    {
        var defaults = new BlinkIdSessionSettings();
        var scanning = defaults.ScanningSettings!;

        var capture = scanning.DocumentCaptureModule!;
        capture = capture.Copy(
            capture.InputImageCropped,
            capture.UnsupportedDocumentsAllowed,
            capture.SecondSideWithNoExtractableDataSkipped,
            capture.PassportDataPageScanOnly,
            faceImageExtractionEnabled: true,
            capture.FaceImagePresenceMandatory,
            capture.InputImageReturnEnabled,
            documentImageReturnEnabled: true,
            capture.InputImageMargin,
            capture.DotsPerInch,
            capture.ExtensionFactor,
            capture.BlurSensitivityLevel,
            capture.ImageWithBlurRejected,
            capture.GlareSensitivityLevel,
            capture.ImageWithGlareRejected,
            capture.TiltSensitivityLevel,
            capture.ImageWithPoorLightingRejected,
            capture.ImageWithHandOcclusionRejected)!;

        var viz = scanning.VizModule!;
        viz = viz.Copy(
            viz.PresenceMandatory,
            signatureImageExtractionEnabled: true,
            viz.CharacterValidationEnabled,
            viz.ResultAggregationEnabled)!;

        var updated = scanning.Copy(
            capture,
            scanning.BarcodeModule,
            scanning.MrzModule,
            viz,
            scanning.MaxAllowedMismatchesPerField)!;

        return new BlinkIdSessionSettings(defaults.InputImageSource, defaults.ScanningMode, updated);
    }

    /// <summary>
    /// IActivityResultCallback — handles the scan result.
    /// </summary>
    public void OnActivityResult(Java.Lang.Object? p0)
    {
        try
        {
            if (p0 is not ActivityResult activityResult) return;

            var contract = new MbBlinkIdScan();
            var scanResult = (BlinkIdScanActivityResult)contract.ParseResult(activityResult.ResultCode, activityResult.Data);

            if (scanResult.Status == ScanActivityResultStatus.Scanned)
            {
                _statusText!.Text = "Document scanned!";
                DisplayResult(scanResult.Result);
            }
            else if (scanResult.Status == ScanActivityResultStatus.Canceled)
            {
                _statusText!.Text = "Scan cancelled.";
            }
            else
            {
                _statusText!.Text = $"Scan status: {scanResult.Status}";
            }
        }
        catch (Exception ex)
        {
            _statusText!.Text = $"Error: {ex.Message}";
        }
    }

    private void DisplayResult(BlinkIdScanningResult? result)
    {
        if (result == null)
        {
            _resultText!.Text = "No result data available";
            return;
        }

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("=== Scan Results ===\n");

        AppendField(sb, "First Name", result.FirstName);
        AppendField(sb, "Last Name", result.LastName);
        AppendField(sb, "Full Name", result.FullName);
        AppendField(sb, "Document Number", result.DocumentNumber);
        AppendField(sb, "Personal ID Number", result.PersonalIdNumber);
        AppendField(sb, "Nationality", result.Nationality);
        AppendField(sb, "Sex", result.Sex);
        AppendField(sb, "Address", result.Address);
        AppendField(sb, "Issuing Authority", result.IssuingAuthority);
        AppendField(sb, "Document Additional Number", result.DocumentAdditionalNumber);
        AppendField(sb, "Document Optional Additional Number", result.DocumentOptionalAdditionalNumber);
        AppendField(sb, "Place Of Birth", result.PlaceOfBirth);
        AppendField(sb, "Marital Status", result.MaritalStatus);
        AppendField(sb, "Profession", result.Profession);
        AppendField(sb, "Race", result.Race);
        AppendField(sb, "Religion", result.Religion);
        AppendField(sb, "Employer", result.Employer);

        AppendDateField(sb, "Date of Birth", result.DateOfBirth);
        AppendDateField(sb, "Date of Issue", result.DateOfIssue);
        AppendDateField(sb, "Date of Expiry", result.DateOfExpiry);

        var face = result.FaceImage();
        var signature = result.SignatureImage();
        var front = result.DocumentImage(ScanningSide.First);
        var back = result.DocumentImage(ScanningSide.Second);
        var input = result.InputImage(ScanningSide.First);
        var input2 = result.InputImage(ScanningSide.Second);
        
        imgFace.SetImageBitmap(face.Bitmap);
        //imgSign.SetImageBitmap(signature.Bitmap);
        imgFront.SetImageBitmap(front.Bitmap);
        imgBack.SetImageBitmap(back.Bitmap);
        _resultText!.Text = sb.ToString();
    }

    private static void AppendField(System.Text.StringBuilder sb, string label, StringResult? field)
    {
        if (field == null) return;
        var values = field.GetValues();
        if (values is { Length: > 0 } && !string.IsNullOrEmpty(values[0]))
            sb.AppendLine($"{label}: {values[0]}");
    }

    private static void AppendDateField(System.Text.StringBuilder sb, string label, DateResult? field)
    {
        if (field == null) return;
        var day = field.Day as Java.Lang.Integer;
        var month = field.Month as Java.Lang.Integer;
        var year = field.Year as Java.Lang.Integer;
        if (day != null && month != null && year != null)
            sb.AppendLine($"{label}: {day.IntValue():D2}/{month.IntValue():D2}/{year.IntValue()}");
    }
}
