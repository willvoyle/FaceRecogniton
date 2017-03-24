using System.Collections.Generic;

namespace Azure.CognitiveServices.FaceRecognition.Domain.Face
{
    public class IdentifyFaceModel
    {
        public string PersonGroupId { get; set; }
        public List<string> FaceIds { get; set; }
    }
}