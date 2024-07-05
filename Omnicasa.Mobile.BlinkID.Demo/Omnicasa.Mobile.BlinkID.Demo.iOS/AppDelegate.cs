// <copyright file="AppDelegate.cs" company="Omnicasa HoangQuach">
// Copyright (c) Omnicasa HoangQuach. All rights reserved.
// </copyright>

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace Omnicasa.Mobile.BlinkID.Demo.iOS
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    using Foundation;
    using Omnicasa.Mobile.BlinkID.Shared;
    using Omnicasa.Mobile.BlinkID.Shared.iOS;
    using UIKit;
    using Unity;

    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.

    /// <inheritdoc/>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.

        /// <inheritdoc/>
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            App.Container.RegisterType<IBlinkIDService, BlinkIDService>();
            this.LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
