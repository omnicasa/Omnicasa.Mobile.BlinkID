using System.Reactive.Disposables;
using System.Reactive.Linq;
using AndroidX.Activity.Result;
using Com.Microblink.Blinkid.Core;
using Com.Microblink.Blinkid.Core.Session;
using Com.Microblink.Blinkid.UX.Contract;
using Omnicasa.Mobile.BlinkID.Shared.Maui;
using Object = Java.Lang.Object;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    internal class BlinkIDActivityResultCallback : Java.Lang.Object, IActivityResultCallback
    {
        public void OnActivityResult(Object? result)
        {
            BlinkIDHelper.OnActivityResult(result);
        }
    }
        
    /// <inheritdoc/>
    public class BlinkIDService : IBlinkIDService, IBlinkIDServiceExtended
    {
#pragma warning disable CS8618
        private static string license;
#pragma warning restore CS8618
        
        /// <inheritdoc/>
        public IObservable<bool> Initialize(string licenseKey)
        {
            return Observable.Create<bool>(o =>
            {
                try
                {
                    if (BlinkIDInitializer.Context == null || BlinkIDInitializer.Activity == null)
                    {
                        o.OnError(new ArgumentException("Please call BlinkIDInitializer.Init"));
                    }
                    
                    license = licenseKey;
                }
                catch (Exception ex)
                {
                    o.OnError(ex);
                }

                o.OnNext(true);
                o.OnCompleted();

                return Disposable.Empty;
            });
        }

        /// <inheritdoc/>
        public IObservable<CardRecognizer> Scan(int limit = 1)
        {
            throw new NotImplementedException("Use ScanExtended instead");
        }

        /// <inheritdoc/>
        public IObservable<CardRecognizerExtended?> ScanExtended(int limit = 1, bool presentAsModal = true)
        {
            var observable = Observable.Create<CardRecognizerExtended?>(o =>
            {
                try
                {
                    int scanTime = 0;

                    if (BlinkIDInitializer.Context == null || BlinkIDInitializer.Activity == null || string.IsNullOrEmpty(license))
                    {
                        throw new ArgumentException("Please call BlinkIDInitializer.Init");
                    }

                    BlinkIDHelper.Scanned += (sender, args) =>
                    {
                        var card = args?.ParseExtended();
                        o.OnNext(card);
                        
                        if (++scanTime == limit)
                        {
                            o.OnCompleted();
                        }
                    };

                    var sdkSettings = new BlinkIdSdkSettings(license);
                    var settings = new BlinkIdScanActivitySettings(sdkSettings, BuildSessionSettings());
                    var contract = new MbBlinkIdScan();
                    
                    var intent = contract.CreateIntent(BlinkIDInitializer.Activity, settings);

                    BlinkIDInitializer.BlinkIdLauncher!.Launch(intent);
                }
                catch (Exception ex)
                {
                    o.OnError(ex);
                }

                return Disposable.Create(() =>
                {
                });
            });

            return observable!;
        }

        public Task<CardRecognizerExtended> ScanID()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enables face/document/signature image return, which is off by default. v8 settings are
        /// immutable and split across scanner modules, so the tree is rebuilt rather than mutated.
        /// </summary>
        private static BlinkIdSessionSettings BuildSessionSettings()
        {
            var defaults = new BlinkIdSessionSettings();
            var scanning = defaults.ScanningSettings
                ?? throw new ArgumentException("ScanningSettings is null");

            var capture = scanning.DocumentCaptureModule
                ?? throw new ArgumentException("DocumentCaptureModule is null");
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

            var viz = scanning.VizModule
                ?? throw new ArgumentException("VizModule is null");
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
    }
}
