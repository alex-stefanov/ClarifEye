using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class TextDetectorController : Controller
    {
        public IActionResult Index(string result)
        {
            TextResultViewModel resultViewModel = new TextResultViewModel();
            resultViewModel.Result = result;
            return View(resultViewModel);
        }
    }
}
