using ClarifEye.Common.Enums;
using ClarifEye.Infrastructure.Interfaces;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class DetectorController(IDetectorService detectorService, HttpClient httpClient)
        : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TrafficLightsDetector()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TrafficLightsDetector(ImageUploadViewModel model)
        {
            TrafficLight result = await detectorService.DetectTrafficLight(model.ImageFile, httpClient);


            return RedirectToAction("Index", "TrafficLightDetector", TrafficLight.Red);
        }
    }
}
