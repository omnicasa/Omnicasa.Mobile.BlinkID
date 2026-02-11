using Android.Content;
using Android.Runtime;
using Com.Microblink.Blinkid.UX.Contract;

namespace Com.Microblink.Blinkid.UX;

public static class MbBlinkIdScanHelper
{
    public static Intent CreateIntent(Context context, BlinkIdScanActivitySettings settings)
    {
        var contractClass = JNIEnv.FindClass("com/microblink/blinkid/ux/contract/MbBlinkIdScan");
        var contractCtor = JNIEnv.GetMethodID(contractClass, "<init>", "()V");
        var contractHandle = JNIEnv.NewObject(contractClass, contractCtor);

        var createIntentMethod = JNIEnv.GetMethodID(contractClass, "createIntent",
            "(Landroid/content/Context;Lcom/microblink/blinkid/ux/contract/BlinkIdScanActivitySettings;)Landroid/content/Intent;");
        var intentHandle = JNIEnv.CallObjectMethod(contractHandle, createIntentMethod,
            new JValue(context), new JValue(settings));

        var intent = Java.Lang.Object.GetObject<Intent>(intentHandle, JniHandleOwnership.TransferLocalRef)!;
        JNIEnv.DeleteLocalRef(contractHandle);
        return intent;
    }

    public static BlinkIdScanActivityResult ParseResult(int resultCode, Intent? data)
    {
        var contractClass = JNIEnv.FindClass("com/microblink/blinkid/ux/contract/MbBlinkIdScan");
        var contractCtor = JNIEnv.GetMethodID(contractClass, "<init>", "()V");
        var contractHandle = JNIEnv.NewObject(contractClass, contractCtor);

        var parseResultMethod = JNIEnv.GetMethodID(contractClass, "parseResult",
            "(ILandroid/content/Intent;)Lcom/microblink/blinkid/ux/contract/BlinkIdScanActivityResult;");
        var resultHandle = JNIEnv.CallObjectMethod(contractHandle, parseResultMethod,
            new JValue(resultCode), new JValue(data));

        var result = Java.Lang.Object.GetObject<BlinkIdScanActivityResult>(resultHandle,
            JniHandleOwnership.TransferLocalRef)!;
        JNIEnv.DeleteLocalRef(contractHandle);
        return result;
    }
}
