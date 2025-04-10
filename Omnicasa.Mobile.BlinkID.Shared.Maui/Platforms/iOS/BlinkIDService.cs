using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Omnicasa.Mobile.BlinkID.Maui.iOS;
using Omnicasa.Mobile.BlinkID.Shared.Maui;
using UIKit;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Shared.iOS
#pragma warning restore SA1300
{
    /// <inheritdoc/>
    public class BlinkIDService : IBlinkIDServiceExtended
    {
        /// <inheritdoc/>
        public IObservable<bool> Initialize(string licenseKey)
        {
            return Observable.Create<bool>(o =>
            {
                // This package support iOS min 13
#pragma warning disable CA1416
                var blinkInstance = MBMicroblinkSDK.SharedInstance();
                if (blinkInstance == null)
                {
                    o.OnError(new NotSupportedException());
                }

                blinkInstance!.SetLicenseKey(licenseKey, (error) =>
                {
                    o.OnError(new Exception());
                });
#pragma warning restore CA1416
                o.OnNext(true);
                o.OnCompleted();

                return Disposable.Empty;
            });
        }

        /// <inheritdoc/>
        public IObservable<CardRecognizer?> Scan(int limit = 1)
        {
            throw new NotImplementedException("Use ScanExtended instead");
        }

        /// <inheritdoc/>
        public IObservable<CardRecognizerExtended?> ScanExtended(int limit = 1, bool presentAsModal = true)
        {
            UIViewController? scannerViewcontroller = null;
            CustomMBBlinkIdOverlayViewControllerDelegate? customDeletegate = null;
            MBBlinkIdMultiSideRecognizer? blinkIdMultiSideRecognizer = null;

            var observable = Observable.Create<CardRecognizerExtended?>(o =>
            {
                try
                {
                    int scanTime = 0;

                    // This package support iOS min 13
#pragma warning disable CA1416
                    blinkIdMultiSideRecognizer = new MBBlinkIdMultiSideRecognizer
                    {
                        ReturnFullDocumentImage = true,
                    };
                    var mBBlinkIdOverlaySettings = new MBBlinkIdOverlaySettings();

                    var mBRecognizerCollection = new MBRecognizerCollection(
                        new[]
                        {
                            blinkIdMultiSideRecognizer,
                        });
#pragma warning restore CA1416

                    customDeletegate = new CustomMBBlinkIdOverlayViewControllerDelegate(null);
                    customDeletegate.Scanned += (object? s, RecognizingState e) =>
                    {
                        if (e == RecognizingState.DidFinishedScanningValid)
                        {
                            // This package support iOS min 13
#pragma warning disable CA1416
                            if (blinkIdMultiSideRecognizer.Result != null)
                            {
                                o.OnNext(blinkIdMultiSideRecognizer.Result.ParseExtended());
                            }
#pragma warning restore CA1416

                            if (++scanTime == limit)
                            {
                                scannerViewcontroller?.DismissViewController(true, null);
                                scannerViewcontroller?.Dispose();
                                scannerViewcontroller = null;
                                customDeletegate = null;
                                o.OnCompleted();
                            }
                        }
                        else if (e == RecognizingState.DidTapClose)
                        {
                            scannerViewcontroller?.DismissViewController(true, null);
                            o.OnCompleted();
                        }
                    };

                    // This package support iOS min 13
#pragma warning disable CA1416
                    var mBBlinkIdOverlayViewController = new MBBlinkIdOverlayViewController(
                        mBBlinkIdOverlaySettings,
                        mBRecognizerCollection,
                        customDeletegate);

                    var recognizerRunneViewController = MBViewControllerFactory
                        .RecognizerRunnerViewControllerWithOverlayViewController(mBBlinkIdOverlayViewController);
#pragma warning restore CA1416

                    if (recognizerRunneViewController == null)
                    {
                        o.OnError(new ArgumentException("recognizerRunneViewController is null"));
                    }

                    scannerViewcontroller = ObjCRuntime.Runtime.GetINativeObject<UIViewController>(
                            recognizerRunneViewController!.Handle, false);
                    if (scannerViewcontroller == null)
                    {
                        o.OnError(new ArgumentException("scannerViewcontroller is null"));
                    }

                    var keyWindow = PlatformHelper.KeyWindow();
                    if (keyWindow == null
                        || keyWindow.RootViewController == null)
                    {
                        o.OnError(new InvalidOperationException("Expect KeyWindow"));
                    }
                    
                    var currentViewController = Platform.GetCurrentUIViewController();
                    if (currentViewController == null)
                    {
                        o.OnError(new InvalidOperationException("Expect active UIViewController"));
                    }

                    if (presentAsModal)
                    {
                        Platform.GetCurrentUIViewController();
#pragma warning disable CA1422
                        currentViewController!.PresentModalViewController(
                            scannerViewcontroller!,
                            true);
#pragma warning restore CA1422
                    }
                    else
                    {
                        currentViewController!.PresentViewController(
                            scannerViewcontroller!,
                            true,
                            null);
                    }
                    
                }
                catch (Exception ex)
                {
                    o.OnError(ex);
                }

                return Disposable.Create(() =>
                {
                    scannerViewcontroller?.Dispose();
                    scannerViewcontroller = null;
                    customDeletegate = null;
                });
            });

            return observable;
        }

        /// <inheritdoc/>
        public Task<CardRecognizerExtended> ScanID()
        {
            throw new NotImplementedException();
        }
    }
}
