using ClarifEye.Infrastructure.Interfaces;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ClarifEye.Web.Controllers
{
    public class ScenerySynthesizer(
        ITranslatorService service,
        ITextToSpeechService ttsService) : Controller
    {
        private readonly HttpClient httpClient = new();
        public IActionResult Index(string result)
        {
            SceneryResultViewModel model = new SceneryResultViewModel();
            model.Result = result;
            return View(model);
        }

        [Route("scenerysynthesizer/speak/{text}")]
        public async Task<IActionResult> Speak(string text, [FromQuery] string voice = "nova")
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("Text is required.");

            var audioBytes = await ttsService.SynthesizeSpeechAsync(httpClient, text, voice);
            return File(audioBytes, "audio/mpeg", "speech.mp3");
        }
    }
}
