﻿using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Com.Microblink;
using Com.Microblink.Entities.Recognizers;
using Com.Microblink.Entities.Recognizers.Blinkid.Generic;
using Com.Microblink.Intent;
using Com.Microblink.Uisettings;
using Com.Microblink.Util;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <inheritdoc/>
    public class BlinkIDService : IBlinkIDService
    {
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

                    MicroblinkSDK.SetLicenseKey(licenseKey, BlinkIDInitializer.Context);
                    MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;
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
            BlinkIdCombinedRecognizer? blinkIdMultiSideRecognizer = null;
            RecognizerBundle? recognizerBundle = null;

            var observable = Observable.Create<CardRecognizer?>(o =>
            {
                try
                {
                    int scanTime = 0;

                    if (BlinkIDInitializer.Context == null || BlinkIDInitializer.Activity == null)
                    {
                        o.OnError(new ArgumentException("Please call BlinkIDInitializer.Init"));
                    }

                    blinkIdMultiSideRecognizer = new BlinkIdCombinedRecognizer();
                    blinkIdMultiSideRecognizer.SetReturnFullDocumentImage(true);
                    blinkIdMultiSideRecognizer.SetReturnFaceImage(true);

                    recognizerBundle = new RecognizerBundle(blinkIdMultiSideRecognizer);

                    if (RecognizerCompatibility.GetRecognizerCompatibilityStatus(BlinkIDInitializer.Context)
                    != RecognizerCompatibilityStatus.RecognizerSupported)
                    {
                        o.OnError(new NotSupportedException("BlinkID is not supported!"));
                    }

                    BlinkIDHelper.Scanned += (object s, RecognizingState e) =>
                    {
                        if (blinkIdMultiSideRecognizer.GetResult() is BlinkIdCombinedRecognizer.Result result)
                        {
                            o.OnNext(result.Parse());
                        }

                        if (++scanTime == limit)
                        {
                            o.OnCompleted();
                        }
                    };

                    var blinkidUISettings = new BlinkIdUISettings(recognizerBundle);
                    ActivityRunner.StartActivityForResult(
                        BlinkIDInitializer.Activity,
                        BlinkIDConstants.BLINK_SCAN_REQUEST_ID,
                        blinkidUISettings);
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
    }
}
