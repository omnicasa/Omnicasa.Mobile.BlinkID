namespace Omnicasa.Mobile.BlinkID.Shared.Maui
{
    public class CardRecognizerExtended : CardRecognizer
    {
        public ImageSource? FrontCameraFrame { get; set; }

        public ImageSource? BackCameraFrame { get; set; }

        public ImageSource? BarcodeCameraFrame { get; set; }
    }
}