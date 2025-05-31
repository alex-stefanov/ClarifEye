using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using ClarifEye.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ClarifEye.Infrastructure.Implementations;

public class TextToSpeechService(
    HttpClient httpClient,
    IConfiguration config)
        : ITextToSpeechService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _apiKey = config["OpenAI:ApiKey"];

    public async Task<byte[]> SynthesizeSpeechAsync(
        string text,
        string voice = "nova")
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/audio/speech");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        var body = new
        {
            model = "tts-1",
            input = text,
            voice = voice,
            response_format = "mp3"
        };

        request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsByteArrayAsync();
    }
}