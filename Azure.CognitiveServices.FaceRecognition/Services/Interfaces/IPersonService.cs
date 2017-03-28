using Azure.CognitiveServices.FaceRecognition.Domain.Person;

namespace Azure.CognitiveServices.FaceRecognition.Services.Interfaces
{
    public interface IPersonService
    {
        AddFaceToPersonResult AddFaceToPerson(byte[] iamge, string personGroupId, string personId, string descrption = null);
        GetPersonResult GetPerson(string personGroupId, string personId);
        AddPersonResult AddPerson(AddPersonModel model, string personGroupId);
    }
}