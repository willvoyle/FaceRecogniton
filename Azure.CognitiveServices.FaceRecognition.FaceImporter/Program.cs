using Azure.CognitiveServices.FaceRecognition.FaceImporter.Helpers;
using Azure.CognitiveServices.FaceRecognition.FaceImporter.Processor;
using System;
using System.Linq;

namespace Azure.CognitiveServices.FaceRecognition.FaceImporter
{
    public class Program
    {
        private static DirectoryProvider _directoryProvider = new DirectoryProvider();
        private static ConfigurationManagerProvider _configurationManagerProvider = new ConfigurationManagerProvider();
        private static ImageProcessor _imageProcessor = new ImageProcessor();

        public static void Main(string[] args)
        {

            var picturesMarketingFolder = _configurationManagerProvider.AppSettings["faceFolder"];

            var imageList = _directoryProvider.EnumerateFiles(picturesMarketingFolder, "*.jpg").ToList();

            _imageProcessor.ProcessPictures(imageList);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
