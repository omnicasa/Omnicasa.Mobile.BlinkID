using Newtonsoft.Json;

namespace Omnicasa.Mobile.BlinkID.Shared.Maui
{
    public class CardRecognizerExtended : CardRecognizer
    {
        [JsonIgnore]
        public Stream? EncodedFaceImage { get; set; }

        [JsonIgnore]
        public Stream? EncodedFullDocumentBackImage { get; set; }

        [JsonIgnore]
        public Stream? EncodedFullDocumentFrontImage { get; set; }

        [JsonIgnore]
        public Stream? EncodedSignatureImage { get; set; }

        [JsonIgnore]
        public ImageSource? FaceImage { get; set; }

        [JsonIgnore]
        public ImageSource? FullDocumentBackImage { get; set; }

        [JsonIgnore]
        public ImageSource? FullDocumentFrontImage { get; set; }

        [JsonIgnore]
        public ImageSource? SignatureImage { get; set; }
    }
}