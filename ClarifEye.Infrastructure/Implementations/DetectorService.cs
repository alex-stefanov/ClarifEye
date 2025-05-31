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
                var response = await client.PostAsync("http://localhost:8000/trafic_lights/detect", content);

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
        public async Task<string> RecognizeText(IFormFile image, HttpClient client)
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
                var response = await client.PostAsync("http://localhost:8000/text/detect", content);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseString)) throw new ArgumentNullException("Invalid Response");

                return responseString;
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentNullException($"Invalid API call. {ex.Message}");
            }
        }
        public async Task<Color> RecognizeColor(IFormFile image, HttpClient client)
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
                var response = await client.PostAsync("http://localhost:8000/color/detect", content);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

                ColorDetectorResponse result = JsonSerializer.Deserialize<ColorDetectorResponse>(responseString);
                if (result is null) throw new ArgumentNullException("Invalid Response");

                Color color = Color.Black;
                if (result.Prediction == "black") color = Color.Black;
                else if (result.Prediction == "blue") color = Color.Blue;
                else if (result.Prediction == "brown") color = Color.Brown;
                else if (result.Prediction == "green") color = Color.Green;
                else if (result.Prediction == "gray") color = Color.Gray;
                else if (result.Prediction == "orange") color = Color.Orange;
                else if (result.Prediction == "pink") color = Color.Pink;
                else if (result.Prediction == "purple") color = Color.Purple;
                else if (result.Prediction == "red") color = Color.Red;
                else if (result.Prediction == "silver") color = Color.Silver;
                else if (result.Prediction == "white") color = Color.White;
                else if (result.Prediction == "yellow") color = Color.Yellow;
                return color;
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentNullException($"Invalid API call. {ex.Message}");
            }
        }
    }
}
