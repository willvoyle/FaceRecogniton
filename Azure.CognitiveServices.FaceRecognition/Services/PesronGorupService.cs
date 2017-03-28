using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Azure.CognitiveServices.FaceRecognition.Services
{
    public class PesronGorupService : IPesronGorupService
    {
        private readonly HttpClient _client;

        public PesronGorupService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6ec53ba17581465594b8a7e989272787");
        }

        public void Train(string personGroupId)
        {
            var uri = $"https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/train";

            HttpResponseMessage response;

            using (var content = new StringContent(string.Empty))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = _client.PostAsync(uri, content).Result;
            };
        }
    }
}
