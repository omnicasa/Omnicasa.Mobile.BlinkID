using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Omnicasa.Mobile.BlinkID.Maui.iOS;
using Omnicasa.Mobile.BlinkID.Shared.Maui;

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
                OmnBlinkIDScanner.Initialize(licenseKey, error =>
                {
                    if (error != null)
                    {
                        o.OnError(new InvalidOperationException(error.LocalizedDescription));
                        return;
                    }

                    o.OnNext(true);
                    o.OnCompleted();
                });

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
            // v8 always presents modally — the SDK owns its own full-screen host controller.
            return Observable.Create<CardRecognizerExtended?>(o =>
            {
                try
                {
                    var presenter = Platform.GetCurrentUIViewController()
                        ?? throw new InvalidOperationException("Expect active UIViewController");

                    int scanTime = 0;

                    void Present()
                    {
                        OmnBlinkIDScanner.Present(presenter, (result, error) =>
                        {
                            if (error != null)
                            {
                                o.OnError(new InvalidOperationException(error.LocalizedDescription));
                                return;
                            }

                            // null result means the user cancelled
                            if (result == null)
                            {
                                o.OnCompleted();
                                return;
                            }

                            o.OnNext(result.ParseExtended());

                            if (++scanTime >= limit)
                            {
                                o.OnCompleted();
                            }
                            else
                            {
                                Present();
                            }
                        });
                    }

                    Present();
                }
                catch (Exception ex)
                {
                    o.OnError(ex);
                }

                return Disposable.Empty;
            });
        }

        /// <inheritdoc/>
        public Task<CardRecognizerExtended> ScanID()
        {
            throw new NotImplementedException();
        }
    }
}
