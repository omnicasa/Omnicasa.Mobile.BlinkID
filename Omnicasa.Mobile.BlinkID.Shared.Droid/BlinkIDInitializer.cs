using Android.App;
using Android.Content;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>BlinkIDInitializer.</summary>
    public static class BlinkIDInitializer
    {
        /// <summary>Context.</summary>
        public static Context? Context { get; set; }

        /// <summary>Activity.</summary>
        public static Activity? Activity { get; set; }

        /// <summary>
        /// Init.
        /// </summary>
        /// <param name="context">Context.</param>
        public static void Init(Context? context, Activity? activity)
        {
            Context = context;
            Activity = activity;
        }
    }
}
