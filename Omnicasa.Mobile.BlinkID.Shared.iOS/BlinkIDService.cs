using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Omnicasa.Mobile.BlinkID.iOS;
using UIKit;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Shared.iOS
#pragma warning restore SA1300
{
    /// <inheritdoc/>
    public class BlinkIDService : IBlinkIDService
    {
        /// <inheritdoc/>
        public IObservable<bool> Initialize(string licenseKey)
        {
            return Observable.Create<bool>(o =>
            {
                var blinkInstance = MBMicroblinkSDK.SharedInstance();
                if (blinkInstance == null)
                {
                    o.OnError(new NotSupportedException());
                }

                blinkInstance!.SetLicenseKey(licenseKey, (error) =>
                {
                    o.OnError(new Exception());
                });

                o.OnNext(true);
                o.OnCompleted();

                return Disposable.Empty;
            });
        }

        /// <inheritdoc/>
        public IObservable<CardRecognizer?> Scan(int limit = 1)
        {
            UIViewController? scannerViewcontroller = null;
            CustomMBBlinkIdOverlayViewControllerDelegate? customDeletegate = null;
            MBBlinkIdMultiSideRecognizer? blinkIdMultiSideRecognizer = null;

            var observable = Observable.Create<CardRecognizer?>(o =>
            {
                try
                {
                    int scanTime = 0;

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

                    customDeletegate = new CustomMBBlinkIdOverlayViewControllerDelegate(null);
                    customDeletegate.Scanned += (object s, RecognizingState e) =>
                    {
                        if (e == RecognizingState.DidFinishedScanningValid)
                        {
                            if (blinkIdMultiSideRecognizer.Result != null)
                            {
                                o.OnNext(blinkIdMultiSideRecognizer.Result.Parse());
                            }

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

                    var mBBlinkIdOverlayViewController = new MBBlinkIdOverlayViewController(
                        mBBlinkIdOverlaySettings,
                        mBRecognizerCollection,
                        customDeletegate);

                    var recognizerRunneViewController = MBViewControllerFactory
                        .RecognizerRunnerViewControllerWithOverlayViewController(mBBlinkIdOverlayViewController);

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

                    keyWindow!.RootViewController!.PresentViewController(
                        scannerViewcontroller!,
                        true,
                        null);
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
    }
}
