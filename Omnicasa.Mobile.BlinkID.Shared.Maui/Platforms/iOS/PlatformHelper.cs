using System.Linq;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Shared.iOS
#pragma warning restore SA1300
{
    /// <summary>PlatformHelper.</summary>
    public static class PlatformHelper
    {
#if IOS13_0_OR_GREATER
        /// <summary>
        /// KeyWindow.
        /// </summary>
        /// <returns>UIWindow.</returns>
#pragma warning disable CA1416
        public static UIKit.UIWindow? KeyWindow() =>
            UIKit.UIApplication
                .SharedApplication
                .ConnectedScenes
                .OfType<UIKit.UIWindowScene>()
                .SelectMany(s => s.Windows)
                .FirstOrDefault(w => w.IsKeyWindow);
#pragma warning restore CA1416
#endif
    }
}
