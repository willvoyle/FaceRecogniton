using Azure.CognitiveServices.FaceRecognition.Domain.Person;
using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Azure.CognitiveServices.FaceRecognition.Services
{
    public class PersonService : IPersonService
    {
        public AddFaceToPersonResult AddFaceToPerson(byte[] imageData, string personGroupId, string personId, string descrption = null)
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6ec53ba17581465594b8a7e989272787");

            // Request parameters
            var uri = $"https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/persons/{personId}/persistedFaces";

            HttpResponseMessage response;

            using (var content = new ByteArrayContent(imageData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = client.PostAsync(uri, content).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AddFaceToPersonResult>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
