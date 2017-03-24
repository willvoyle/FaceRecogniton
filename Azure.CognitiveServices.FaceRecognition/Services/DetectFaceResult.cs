namespace Azure.CognitiveServices.FaceRecognition.Services
{
    public class DetectFaceResult
    {
        public string FaceId { get; set; }
        public FaceRectangle FaceRectangle { get; set; }
    }

    public class FaceRectangle
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Left { get; set; }
        public decimal Top { get; set; }
            }
}