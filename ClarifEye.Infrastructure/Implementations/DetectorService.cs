using ClarifEye.Common.DTOS;
using ClarifEye.Common.Enums;
using ClarifEye.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClarifEye.Infrastructure.Implementations
{
    public class DetectorService : IDetectorService
    {
        public async Task<TrafficLight> DetectTrafficLight(IFormFile image, HttpClient client)
        {
            if (image == null || image.Length == 0)
                throw new ArgumentException("Not a valid image");

            using var content = new MultipartFormDataContent();

            using var stream = image.OpenReadStream();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);
            content.Add(fileContent, "file", image.FileName);

            try
            {
                var response = await client.PostAsync("http://localhost:8000/predict", content);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

                TrafficLightResponse result = JsonSerializer.Deserialize<TrafficLightResponse>(responseString);


                TrafficLight status;

                if (result.Color == "backside") status = TrafficLight.BackSide;
                else if (result.Color == "green") status = TrafficLight.Green;
                else if (result.Color == "red") status = TrafficLight.Red;
                else if (result.Color == "yellow") status = TrafficLight.Yellow;
                else throw new ArgumentException("Not found");

                return status;               
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentNullException($"Invalid API call. {ex.Message}");
            }
        }
    }
}
