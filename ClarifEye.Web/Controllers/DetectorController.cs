using ClarifEye.Common.Enums;
using ClarifEye.Infrastructure.Interfaces;
using ClarifEye.Web.Models;
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

            return RedirectToAction("Index", "TrafficLightDetector", result);
        }
    }
}
