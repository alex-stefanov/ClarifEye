using ClarifEye.Common.Enums;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class ColorDetectorController : Controller
    {
        public IActionResult Index(Color color)
        {
            ColorResultViewModel colorResultViewModel = new ColorResultViewModel();
            colorResultViewModel.Color = color;
            return View(colorResultViewModel);
        }
    }
}
