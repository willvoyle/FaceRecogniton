using Azure.CognitiveServices.FaceRecognition.Domain.Face;

namespace Azure.CognitiveServices.FaceRecognition.Services.Interfaces
{
    public interface IFaceService
    {
        DetectFaceResult DetectFace(byte[] imageData);
        VerifyFaceResult VerifyFace(VerifyFaceModel verifyModel);
    }
}