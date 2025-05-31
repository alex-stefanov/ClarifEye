namespace ClarifEye.Infrastructure.Interfaces;

public interface ITextToSpeechService
{
    Task<byte[]> SynthesizeSpeechAsync(
        string text,
        string voice = "nova");
}