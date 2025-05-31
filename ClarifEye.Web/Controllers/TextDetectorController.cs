using ClarifEye.Common.Enums;
using ClarifEye.Infrastructure.Interfaces;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class TextDetectorController (
        ITranslatorService service,
        ITextToSpeechService ttsService) : Controller
    {
        private readonly HttpClient httpClient = new();

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

        //TODO: when model like it
        [Route("textdetector/speak/{text}")]
        public async Task<IActionResult> Speak(string text, [FromQuery] string voice = "nova")
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("Text is required.");

            var audioBytes = await ttsService.SynthesizeSpeechAsync(httpClient ,text, voice);
            return File(audioBytes, "audio/mpeg", "speech.mp3");
        }
    }
}
