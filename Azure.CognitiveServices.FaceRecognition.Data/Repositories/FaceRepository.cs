using System;
using Azure.CognitiveServices.FaceRecognition.Data.Entities;
using System.Linq;

namespace Azure.CognitiveServices.FaceRecognition.Data.Repositories
{
    public class FaceRepository : IFaceRepository
    {
        private readonly FaceContext _db;

        public FaceRepository()
        {
            _db = new FaceContext();
        }

        public void Add(Face face)
        {
            _db.Faces.Add(face);
            _db.SaveChanges();
        }

        public bool Exist(string currentFileName)
        {
            return _db.Faces.Any(f => f.Name == currentFileName);
        }

        public Face Get(Guid pesronId)
        {
            return _db.Faces.SingleOrDefault(f => f.PersonId == pesronId);
        }
    }
}
