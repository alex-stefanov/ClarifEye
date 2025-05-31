using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class TrafficLightDetector : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
