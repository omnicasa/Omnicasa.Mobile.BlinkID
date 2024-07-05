// <copyright file="App.xaml.cs" company="Omnicasa HoangQuach">
// Copyright (c) Omnicasa HoangQuach. All rights reserved.
// </copyright>

namespace Omnicasa.Mobile.BlinkID.Demo
{
    using CommonServiceLocator;
    using Unity;
    using Unity.ServiceLocation;
    using Xamarin.Forms;

    /// <inheritdoc/>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            var unityServiceLocator = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
            this.MainPage = new MainPage();
        }

        /// <summary>Gets unityContainer.</summary>
        public static UnityContainer Container { get; } = new UnityContainer();

        /// <inheritdoc/>
        protected override void OnStart()
        {
            // Method intentionally left empty.
        }

        /// <inheritdoc/>
        protected override void OnSleep()
        {
            // Method intentionally left empty.
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
            // Method intentionally left empty.
        }
    }
}
