﻿using System.Linq;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Shared.iOS
#pragma warning restore SA1300
{
    /// <summary>PlatformHelper.</summary>
    public static class PlatformHelper
    {
        /// <summary>
        /// KeyWindow.
        /// </summary>
        /// <returns>UIWindow.</returns>
        public static UIKit.UIWindow? KeyWindow() =>
            UIKit.UIApplication
                .SharedApplication
                .ConnectedScenes
                .OfType<UIKit.UIWindowScene>()
                .SelectMany(s => s.Windows)
                .FirstOrDefault(w => w.IsKeyWindow);
    }
}