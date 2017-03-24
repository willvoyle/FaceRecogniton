using System.Collections.Generic;

namespace Azure.CognitiveServices.FaceRecognition.Domain.Face
{
    public class IdentifyFaceResult
    {
        public string FaceId { get; set; }
        public List<IdentifyFace> Candidates { get; set; }
    }

    public class IdentifyFace
    {
        public string PersonId { get; set; }
        public float Confidence { get; set; }
    }
}