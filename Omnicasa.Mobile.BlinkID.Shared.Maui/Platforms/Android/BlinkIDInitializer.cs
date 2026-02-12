using Android.App;
using Android.Content;
using AndroidX.AppCompat.App;

namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>BlinkIDInitializer.</summary>
    public static class BlinkIDInitializer
    {
        /// <summary>Context.</summary>
        public static Context? Context { get; set; }

        /// <summary>Activity.</summary>
        public static AppCompatActivity? Activity { get; set; }

        /// <summary>
        /// Init.
        /// </summary>
        /// <param name="context">Context.</param>
        public static void Init(Context? context, AppCompatActivity? activity)
        {
            Context = context;
            Activity = activity;
        }
    }
}
