using Azure.CognitiveServices.FaceRecognition.FaceImporter.Extensions;
using Azure.CognitiveServices.FaceRecognition.Services;
using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace Azure.CognitiveServices.FaceRecognition.FaceImporter.Processor
{
    public class ImageProcessor
    {
        private readonly IPersonService _personService;

        public ImageProcessor()
        {
            _personService = new PersonService();
        }

        public void ProcessPictures(IEnumerable<string> jpgFilePaths)
        {
            foreach (var currentFile in jpgFilePaths)
            {
                ProcessPicture(currentFile);
            }
        }

        private void ProcessPicture(string currentFile)
        {
            //AddPerson

            //AddFaceToPerson
            var imageData = CreateBitMap(currentFile).ToByteArray();

            var result = _personService.AddFaceToPerson(imageData, "london", "3026587");
        }

        private static Image CreateBitMap(string filePath)
        {
            return new Bitmap(filePath);
        }
    }

   
}
