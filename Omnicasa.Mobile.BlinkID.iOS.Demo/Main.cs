using UIKit;

#pragma warning disable SA1300
namespace Omnicasa.Mobile.BlinkID.iOS.Demo
#pragma warning restore SA1300
{
    #pragma warning disable S1118
    /// <inheritdoc/>
    public class Application
    {
        /// <inheritdoc/>
        // This is the main entry point of the application.
#pragma warning disable SA1400 // Access modifier should be declared
        static void Main(string[] args)
#pragma warning restore SA1400 // Access modifier should be declared
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
