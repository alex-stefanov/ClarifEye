using ClarifEye.Common.Enums;
using ClarifEye.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class DetectorController(IDetectorService detectorService)
        : Controller
    {
        private readonly HttpClient httpClient = new();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TrafficLightsDetector(IFormFile file)
        {
            TrafficLight result = await detectorService.DetectTrafficLight(file, httpClient);

            return RedirectToAction("Index", "TrafficLightDetector", new { type = result });
        }
        [HttpPost]
        public async Task<IActionResult> TextDetector(IFormFile file)
        {
            string result = await detectorService.RecognizeText(file, httpClient);
            return RedirectToAction("Index", "TextDetector", new { result = result });
        }

        [HttpPost]
        public async Task<IActionResult> ColorDetector(IFormFile file)
        {
            Color result = await detectorService.RecognizeColor(file, httpClient);
            return RedirectToAction("Index", "ColorDetector", new { color = result });
        }
    }
}