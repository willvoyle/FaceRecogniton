using Azure.CognitiveServices.FaceRecognition.Data.Repositories;
using Azure.CognitiveServices.FaceRecognition.Domain.Person;
using Azure.CognitiveServices.FaceRecognition.FaceImporter.Extensions;
using Azure.CognitiveServices.FaceRecognition.Services;
using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Azure.CognitiveServices.FaceRecognition.FaceImporter.Processor
{
    public class ImageProcessor
    {
        private readonly IPersonService _personService;
        private readonly IFaceRepository _faceRepository;
        private readonly IPesronGorupService _pesronGorupService;
        
        private const string PesronGroupId = "london";

        public ImageProcessor()
        {
            _personService = new PersonService();
            _faceRepository = new FaceRepository();
            _pesronGorupService = new PesronGorupService();
        }

        public void ProcessPictures(IEnumerable<string> jpgFilePaths)
        {
            foreach (var currentFile in jpgFilePaths)
            {
                ProcessPicture(currentFile);
            }

            _pesronGorupService.Train(PesronGroupId);
        }

        private void ProcessPicture(string currentFile)
        {
            var currentFileName = Path.GetFileNameWithoutExtension(currentFile.Split('\\').LastOrDefault());

            //GetPerson
            if (_faceRepository.Exist(currentFileName))
            {
                return;
            }

            //AddPerson
            var addPersonModel = new AddPersonModel { Name = currentFileName };

            var addPersonResult = _personService.AddPerson(addPersonModel, PesronGroupId);

            //AddFaceToPerson
            var imageData = CreateBitMap(currentFile).ToByteArray();

            var result = _personService.AddFaceToPerson(imageData, PesronGroupId, addPersonResult.PersonId);

            //AddToDb
            var faceEntity = new Data.Entities.Face { PersonId = Guid.Parse(addPersonResult.PersonId), Name = currentFileName, Image = imageData };
            _faceRepository.Add(faceEntity);
        }

        private static Image CreateBitMap(string filePath)
        {
            return new Bitmap(filePath);
        }
    }
}
