using Azure.CognitiveServices.FaceRecognition.Services;
using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using System.IO;
using System.Web.Mvc;

namespace Azure.CognitiveServices.FaceRecognition.Mvc.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IFaceService _faceService;

        public PictureController()
        {
            _personService = new PersonService();
            _faceService = new FaceService();
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
            var personId = "e64bd0d7-6d3a-4b55-81ed-b2d93b37ae37";
            var pesronGorupId = "london";

            var bytes = Request.InputStream.ToByteArray();

            var detectResult = _faceService.DetectFace(bytes);

            if (detectResult == null)
            {

            }
            var verifyResult = _faceService.VerifyFace(new Domain.Face.VerifyFaceModel { FaceId = detectResult.FaceId, PersonGroupId = pesronGorupId, PersonId = personId });

            return View("Index");
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