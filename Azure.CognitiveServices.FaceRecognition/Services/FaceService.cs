﻿using Azure.CognitiveServices.FaceRecognition.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Azure.CognitiveServices.FaceRecognition.Domain.Face;
using System.Collections.Generic;
using System.Linq;

namespace Azure.CognitiveServices.FaceRecognition.Services
{
    public class FaceService : IFaceService
    {
        private readonly HttpClient _client;

        public FaceService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6ec53ba17581465594b8a7e989272787");
        }

        public IdentifyFaceResult IdentifyFace(IdentifyFaceModel identifyModel)
        {
            var uri = "https://westus.api.cognitive.microsoft.com/face/v1.0/identify";

            HttpResponseMessage response;

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(identifyModel));
            
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = _client.PostAsync(uri, content).Result;
            };

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<IdentifyFaceResult>>(response.Content.ReadAsStringAsync().Result).FirstOrDefault();
        }

        public DetectFaceResult DetectFace(byte[] imageData)
        {
            var uri = $"https://westus.api.cognitive.microsoft.com/face/v1.0/detect";

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

            return JsonConvert.DeserializeObject<List<DetectFaceResult>>(response.Content.ReadAsStringAsync().Result).FirstOrDefault();
        }

        public VerifyFaceResult VerifyFace(VerifyFaceModel verifyModel)
        {
            var uri = $"https://westus.api.cognitive.microsoft.com/face/v1.0/verify";

            HttpResponseMessage response;

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(verifyModel));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = _client.PostAsync(uri, content).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<VerifyFaceResult>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
