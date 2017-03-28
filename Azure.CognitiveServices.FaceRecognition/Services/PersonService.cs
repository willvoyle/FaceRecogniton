using Azure.CognitiveServices.FaceRecognition.Domain.Person;
using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Text;

namespace Azure.CognitiveServices.FaceRecognition.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _client;

        public PersonService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6ec53ba17581465594b8a7e989272787");
        }

        public AddFaceToPersonResult AddFaceToPerson(byte[] imageData, string personGroupId, string personId, string descrption = null)
        {
            var uri = $"https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/persons/{personId}/persistedFaces";

            HttpResponseMessage response;

            using (var content = new ByteArrayContent(imageData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = _client.PostAsync(uri, content).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AddFaceToPersonResult>(response.Content.ReadAsStringAsync().Result);
        }

        public AddPersonResult AddPerson(AddPersonModel model, string personGroupId)
        {
            var uri = $"https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/persons";

            HttpResponseMessage response;

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
            
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = _client.PostAsync(uri, content).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AddPersonResult>(response.Content.ReadAsStringAsync().Result);
        }

        public GetPersonResult GetPerson(string personGroupId, string personId)
        {
            var uri = $"https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/persons/{personId}";

            var response = _client.GetAsync(uri).Result;

            if (response == null)
            {
                return null;
            }

            return new GetPersonResult();
        }
    }
}
