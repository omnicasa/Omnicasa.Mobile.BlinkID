using Android.App;
using Android.Content;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
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

        public static ActivityResultLauncher? BlinkIdLauncher { get; set; }

        /// <summary>
        /// Init.
        /// </summary>
        /// <param name="context">Context.</param>
        public static void Init(Context? context, AppCompatActivity? activity)
        {
            Context = context;
            Activity = activity;

            if (activity != null)
            {
                BlinkIdLauncher = activity.RegisterForActivityResult(
                    new ActivityResultContracts.StartActivityForResult(),
                    new BlinkIDActivityResultCallback());
            }
        }
    }
}
