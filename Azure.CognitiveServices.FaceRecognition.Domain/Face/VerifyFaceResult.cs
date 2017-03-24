namespace Azure.CognitiveServices.FaceRecognition.Domain.Face
{
    public class VerifyFaceResult
    {
        public bool IsIdentical { get; set; }
        public decimal Confidence { get; set; }
    }
}
