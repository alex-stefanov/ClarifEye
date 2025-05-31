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
            TextResultViewModel resultViewModel = new()
            {
                Text = result,
                Language = Common.Enums.Language.English
            };

            return View(resultViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Translate (string text, Language language)
        {

            string result = await service.TranslateTextAsync(text, language);
            return RedirectToAction("Index", new { result = result});
        }

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
