using ClarifEye.Common.Enums;
using ClarifEye.Infrastructure.Interfaces;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class TextDetectorController (ITranslatorService service) : Controller
    {
        [HttpGet]
        public IActionResult Index(string result)
        {
            TextResultViewModel resultViewModel = new TextResultViewModel();
            resultViewModel.Text = result;
            resultViewModel.Language = Common.Enums.Language.English;
            return View(resultViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Translate (TextResultViewModel model)
        {
            string result = await service.TranslateTextAsync(model.Text, model.Language ?? Language.English);
            return RedirectToAction("Index", result);
        }
    }
}
