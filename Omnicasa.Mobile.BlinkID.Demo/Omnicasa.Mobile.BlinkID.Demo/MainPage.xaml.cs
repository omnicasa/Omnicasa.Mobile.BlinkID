// <copyright file="MainPage.xaml.cs" company="Omnicasa HoangQuach">
// Copyright (c) Omnicasa HoangQuach. All rights reserved.
// </copyright>

namespace Omnicasa.Mobile.BlinkID.Demo
{
    using System;
    using System.Reactive.Linq;
    using CommonServiceLocator;
    using Omnicasa.Mobile.BlinkID.Shared;
    using Xamarin.Forms;

    /// <inheritdoc/>
    public partial class MainPage : ContentPage
    {
#pragma warning disable SA1303
#pragma warning disable SA1600
        public const string iOSLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";
#pragma warning restore SA1600
#pragma warning restore SA1303

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var blinkService = ServiceLocator.Current.GetInstance<IBlinkIDService>();
            if (blinkService != null)
            {
                blinkService
                    .Initialize(iOSLic)
                    .Catch<bool, Exception>(_ => Observable.Return(false))
                    .Subscribe(initialized =>
                    {
                        System.Diagnostics.Debug.WriteLine($"Register BLINKID with result => {initialized}");
                    });
            }
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            var blinkService = ServiceLocator.Current.GetInstance<IBlinkIDService>();
            if (blinkService != null)
            {
                blinkService
                    .Scan()
                    .Catch<CardRecognizer, Exception>(_ => Observable.Return<CardRecognizer>(null))
                    .Subscribe(card =>
                    {
                        System.Diagnostics.Debug.WriteLine($"Card => {card.FirstName}");
                    });
            }
        }
    }
}
