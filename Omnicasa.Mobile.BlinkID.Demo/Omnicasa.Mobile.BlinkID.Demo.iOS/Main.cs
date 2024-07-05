// <copyright file="Main.cs" company="Omnicasa HoangQuach">
// Copyright (c) Omnicasa HoangQuach. All rights reserved.
// </copyright>

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.Demo.iOS
#pragma warning restore SA1300
{
    using UIKit;

#pragma warning disable S1118
#pragma warning disable SA1600
#pragma warning disable SA1649
    public class Application
#pragma warning restore SA1649
#pragma warning restore SA1600
#pragma warning restore S1118
    {
        // This is the main entry point of the application.
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
