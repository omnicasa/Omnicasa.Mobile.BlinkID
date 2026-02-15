namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>BlinkIDHelper.</summary>
    public static class BlinkIDHelper
    {
        /// <summary>Scanned.</summary>
        public static EventHandler<Object?>? Scanned { get; set; }

        /// <summary>
        /// OnActivityResult
        /// </summary>
        /// <param name="result"></param>
        public static void OnActivityResult(Object? result)
        {
            Scanned?.Invoke(null, result);
        }
    }
}
