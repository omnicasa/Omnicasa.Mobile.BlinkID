using Newtonsoft.Json;

namespace Omnicasa.Mobile.BlinkID.Shared.Maui
{
    /// <summary>CardRecognizerExtended.</summary>
    public class CardRecognizerExtended : CardRecognizer
    {
        /// <summary>EncodedFaceImage.</summary>
        [JsonIgnore]
        public Stream? EncodedFaceImage { get; set; }

        /// <summary>EncodedFullDocumentBackImage.</summary>
        [JsonIgnore]
        public Stream? EncodedFullDocumentBackImage { get; set; }

        /// <summary>EncodedFullDocumentFrontImage.</summary>
        [JsonIgnore]
        public Stream? EncodedFullDocumentFrontImage { get; set; }

        /// <summary>EncodedSignatureImage.</summary>
        [JsonIgnore]
        public Stream? EncodedSignatureImage { get; set; }

        /// <summary>FaceImage.</summary>
        [JsonIgnore]
        public ImageSource? FaceImage { get; set; }

        /// <summary>FullDocumentBackImage.</summary>
        [JsonIgnore]
        public ImageSource? FullDocumentBackImage { get; set; }

        /// <summary>FullDocumentFrontImage.</summary>
        [JsonIgnore]
        public ImageSource? FullDocumentFrontImage { get; set; }

        /// <summary>SignatureImage.</summary>
        [JsonIgnore]
        public ImageSource? SignatureImage { get; set; }
    }
}