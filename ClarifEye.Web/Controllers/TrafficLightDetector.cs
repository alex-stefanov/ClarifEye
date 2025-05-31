using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class TrafficLightDetector : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TrafficLightValue = (int)type;
            return View();
        }
    }
}
