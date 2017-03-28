using Azure.CognitiveServices.FaceRecognition.Data.Entities;
using System;

namespace Azure.CognitiveServices.FaceRecognition.Data.Repositories
{
    public interface IFaceRepository
    {
        void Add(Face face);
        bool Exist(string currentFileName);
        Face Get(Guid pesronId);
    }
}