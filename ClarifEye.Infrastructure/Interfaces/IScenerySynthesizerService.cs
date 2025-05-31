using Microsoft.AspNetCore.Http;

namespace ClarifEye.Infrastructure.Interfaces;

public interface IScenerySynthesizerService
{
    Task<string> SynthesizeScenery(
        IFormFile imageFile,
        HttpClient httpClient);
}