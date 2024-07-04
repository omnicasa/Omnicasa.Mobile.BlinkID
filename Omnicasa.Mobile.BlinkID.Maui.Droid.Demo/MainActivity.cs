using Com.Microblink.Entities.Recognizers;
using Com.Microblink.Entities.Recognizers.Blinkid.Generic;

namespace Omnicasa.Mobile.BlinkID.Maui.Droid.Demo;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
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

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }
}
