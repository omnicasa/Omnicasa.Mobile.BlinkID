using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Microblink;
using Com.Microblink.Entities.Recognizers;
using Com.Microblink.Entities.Recognizers.Blinkid.Generic;
using Com.Microblink.Intent;
using Com.Microblink.Uisettings;
using Com.Microblink.Util;

namespace Omnicasa.Mobile.BlinkID.Droid.Demo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        const int ACTIVITY_REQUEST_ID = 101;

        // BlinkIdCombinedRecognizer is used for automatic classification and data extraction from the supported
        // document
        BlinkIdCombinedRecognizer blinkidRecognizer;

        // there are plenty of recognizers available - see Android documentation
        // for more information: https://github.com/BlinkID/blinkid-android/blob/master/README.md

        // RecognizerBundle is required for transferring recognizers via Intent to another activity
        // and for loading results from them back.
        RecognizerBundle recognizerBundle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button button = FindViewById<Button>(Resource.Id.startScanningButton);
            // Setup BlinkID before usage
            InitBlinkId();

            // check if BlinkID is supported on current device. Device needs to have camera with autofocus.
            if (RecognizerCompatibility.GetRecognizerCompatibilityStatus(this) != RecognizerCompatibilityStatus.RecognizerSupported)
            {
                button.Enabled = false;
                Toast.MakeText(this, "BlinkID is not supported!", ToastLength.Long).Show();
            }
            else
            {
                button.Click += delegate {
                    // create a settings object for activity that will be used. For ID it's best to
                    // use DocumentUISettings. There are also other UI settings available - check Android documentation
                    var blinkidUISettings = new BlinkIdUISettings(recognizerBundle);

                    // start activity associated with given UI settings. After scanning completes,
                    // OnActivityResult will be invoked
                    ActivityRunner.StartActivityForResult(this, ACTIVITY_REQUEST_ID, blinkidUISettings);
                };
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == ACTIVITY_REQUEST_ID && resultCode == Result.Ok)
            {

                // unfortunately, C# does not support covariant return types, so binding
                // of AAR loses the return type of the Java's GetResult method. Therefore, a cast is required.
                // This is always a safe cast, since the original object in Java is of correct type - type
                // information was lost during conversion to C# due to https://github.com/xamarin/java.interop/pull/216
                var blinkidResult = (BlinkIdCombinedRecognizer.Result)blinkidRecognizer.GetResult();
                // var mrtdResult = (MrtdRecognizer.Result)mrtdRecognizer.GetResult();


                var message = "";

                // we can check ResultState property of the Result to see if the result contains scanned information
                if (blinkidResult.ResultState == Recognizer.Result.State.Valid)
                {
                    message += "BlinkID recognizer result:\n" +
                        "FirstName: " + blinkidResult.FirstName + "\n" +
                        "LastName: " + blinkidResult.LastName + "\n" +
                        "Address: " + blinkidResult.Address + "\n" +
                        "DocumentNumber: " + blinkidResult.DocumentNumber + "\n" +
                        "Sex: " + blinkidResult.Sex + "\n";
                    var dob = blinkidResult.DateOfBirth.Date;
                    if (dob != null)
                    {
                        message +=
                            "DateOfBirth: " + dob.Day + "." +
                                              dob.Month + "." +
                                              dob.Year + ".\n";
                    }
                    var doi = blinkidResult.DateOfIssue.Date;
                    if (doi != null)
                    {
                        message +=
                            "DateOfIssue: " + doi.Day + "." +
                                              doi.Month + "." +
                                              doi.Year + ".\n";

                    }
                    var doe = blinkidResult.DateOfExpiry.Date;
                    if (doe != null)
                    {
                        message +=
                            "DateOfExpiry: " + doe.Day + "." +
                                               doe.Month + "." +
                                               doe.Year + ".\n";

                    }
                    // there are other fields to extract

                    // show full document images
                    if (blinkidResult.FullDocumentFrontImage != null)
                    {
                        // documentImageFrontView.SetImageBitmap(blinkidResult.FullDocumentFrontImage.ConvertToBitmap());
                    }
                    else
                    {
                        // documentImageFrontView.SetImageResource(0);
                    }
                    if (blinkidResult.FullDocumentBackImage != null)
                    {
                        // documentImageBackView.SetImageBitmap(blinkidResult.FullDocumentBackImage.ConvertToBitmap());
                    }
                    else
                    {
                        // documentImageBackView.SetImageResource(0);
                    }

                }

                System.Diagnostics.Debug.WriteLine(message);
            }
        }

        private void InitBlinkId()
        {
            // set license key for Android with package name com.microblink.sample
            MicroblinkSDK.SetLicenseKey("sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdZhZkGlTu9XHOXtHZ5sEIxfrd8QRtGUpBIN4H59/oIIoDep7g5k2bvWM6ectjLQNLLa+8uVtpNekwbLYvD+HFqTXNY78QiDkaZovM6KnsU9ChZhZOoM1du4CJwbGrzRq/+xBNsI6hPWP0PCJyWPADScdvMzlS7hJd4l4IsuPJ2wuUprFFdE9woA68ojyCeu0jj9/5mBfZMqLZ7tZPGzji5q+ZTjqL9ZHHI7ZNHj/SFoOOdH29/fGqW0efquPs+QLtF75pbJ0+rUpTVQH5apFVM9BOvMprs0gE975dNfpgjfBSBtahqqW9XTMlp79Th1/Ht6+w+rYKZUi7O24WBHqUA==", this);

            // Since we plan to transfer large data between activities, we need to enable
            // PersistedOptimised intent data transfer mode.
            // for more information about transfer mode, check android documentation: https://github.com/blinkid/blinkid-android#-passing-recognizer-objects-between-activities
            MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;

            // create recognizers and bundle them into RecognizerBundle
            blinkidRecognizer = new BlinkIdCombinedRecognizer();
            blinkidRecognizer.SetReturnFullDocumentImage(true);
            blinkidRecognizer.SetReturnFaceImage(true);

            recognizerBundle = new RecognizerBundle(blinkidRecognizer);
        }
    }
}
