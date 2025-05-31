using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class ScenerySynthesizer : Controller
    {
        public IActionResult Index(string result)
        {
            SceneryResultViewModel model = new SceneryResultViewModel();
            model.Result = result;
            return View(model);
        }
    }
}
