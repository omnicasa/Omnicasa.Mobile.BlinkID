using System.Reactive.Disposables;
using System.Reactive.Linq;
using AndroidX.Activity.Result;
using Com.Microblink.Blinkid.Core;
using Com.Microblink.Blinkid.UX.Contract;
using Omnicasa.Mobile.BlinkID.Shared.Maui;
using Object = Java.Lang.Object;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>
    /// BlinkIDActivityResultCallback.
    /// </summary>
    internal class BlinkIDActivityResultCallback : Java.Lang.Object, IActivityResultCallback
    {
        /// <inheritdoc/>
        public void OnActivityResult(Object? result)
        {
            BlinkIDHelper.OnActivityResult(result);
        }
    }

    /// <inheritdoc/>
    public class BlinkIDService : IBlinkIDServiceExtended
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static string license;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

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
                        o.OnError(new ArgumentException("Please call BlinkIDInitializer.Init"));
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
                    var settings = new BlinkIdScanActivitySettings(sdkSettings);
                    var scanSettings = settings.ScanningSessionSettings.ScanningSettings;
                    if (scanSettings == null || scanSettings.CroppedImageSettings == null)
                    {
                        o.OnError(new ArgumentException("Please call BlinkIDInitializer.Init"));
                    }
                    else
                    {
                        scanSettings.CroppedImageSettings.ReturnFaceImage = true;
                        scanSettings.CroppedImageSettings.ReturnDocumentImage = true;
                        scanSettings.CroppedImageSettings.ReturnSignatureImage = true;
                    }

                    var contract = new MbBlinkIdScan();
                    if (BlinkIDInitializer.Activity != null)
                    {
                        var intent = contract.CreateIntent(BlinkIDInitializer.Activity, settings);
                        BlinkIDInitializer.BlinkIdLauncher!.Launch(intent);
                    }
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

        /// <summary>
        /// ScanID.
        /// </summary>
        /// <returns>CardRecognizerExtended.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<CardRecognizerExtended> ScanID()
        {
            throw new NotImplementedException();
        }
    }
}
