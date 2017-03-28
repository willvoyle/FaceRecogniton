using Azure.CognitiveServices.FaceRecognition.Data.Repositories;
using Azure.CognitiveServices.FaceRecognition.Domain.Face;
using Azure.CognitiveServices.FaceRecognition.Services;
using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Azure.CognitiveServices.FaceRecognition.Mvc.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IFaceService _faceService;
        private readonly IFaceRepository _faceRepository;

        //TODO: Remove
        private const string personGroupId = "london";

        public PictureController()
        {
            _personService = new PersonService();
            _faceService = new FaceService();
            _faceRepository = new FaceRepository();
        }

        // GET: Picture
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            var imageData = ProcessRequestImage(Request.InputStream);

            var detectResult = _faceService.DetectFace(imageData);

            if (detectResult == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var identityModel = new IdentifyFaceModel { PersonGroupId = personGroupId, FaceIds = new string[] { detectResult.FaceId } };
            var identityResult = _faceService.IdentifyFace(identityModel);

            if (identityResult == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var personId = identityResult.Candidates.FirstOrDefault()?.PersonId;

            if (string.IsNullOrEmpty(personId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var face = _faceRepository.Get(Guid.Parse(personId));

            ViewBag.Name = face?.Name;
            return View("Index");
        }

        private byte[] ProcessRequestImage(Stream stream)
        {
            var reader = new StreamReader(stream);

            return reader.ReadToEnd().ToByteArray();
        }
    }

    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string text)
        {
            int numBytes = (text.Length) / 2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(text.Substring(x * 2, 2), 16);
            }

            return bytes;
        }
    }

    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }

}