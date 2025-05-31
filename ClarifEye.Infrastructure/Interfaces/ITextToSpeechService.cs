namespace ClarifEye.Infrastructure.Interfaces;

public interface ITextToSpeechService
{
    Task<byte[]> SynthesizeSpeechAsync(
        HttpClient httpClient,
        string text,
        string voice = "nova");
}