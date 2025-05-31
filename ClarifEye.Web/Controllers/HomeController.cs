using System.Diagnostics;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult HandleVisionMode(IFormFile file, string visionMode)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("Error", new { message = "No file selected." });
            }

            switch (visionMode)
            {
                case "text":
                    return RedirectToAction("TextDetector", "Detector");

                case "color":
                    return RedirectToAction("ColorDetector", "Detector");

                case "traffic":
                    return RedirectToAction("TrafficLightDetection", "Detector");

                default:
                    return RedirectToAction("Error", new { message = "Invalid vision mode selected." });
            }
        }
    }
}
