using ClarifEye.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Infrastructure.Interfaces
{
    public interface IDetectorService
    {
        public Task<TrafficLight> DetectTrafficLight(IFormFile image, HttpClient httpClient);
        public Task<string> RecognizeText(IFormFile image ,HttpClient httpClient);
        public Task<Color> RecognizeColor(IFormFile image ,HttpClient httpClient);
    }
}
