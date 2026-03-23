namespace Omnicasa.Mobile.BlinkID.Shared.Droid
{
    /// <summary>BlinkIDHelper.</summary>
    public static class BlinkIDHelper
    {
        /// <summary>Scanned.</summary>
        public static EventHandler<object?>? Scanned { get; set; }

        /// <summary>
        /// OnActivityResult.
        /// </summary>
        /// <param name="result">object.</param>
        public static void OnActivityResult(object? result)
        {
            Scanned?.Invoke(null, result);
        }
    }
}
