using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using ClarifEye.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace ClarifEye.Infrastructure.Implementations;

public class TextToSpeechService(
    IConfiguration config)
        : ITextToSpeechService
{
    private readonly string _apiKey = config["OpenAI:ApiKey"];
    private static readonly ConcurrentDictionary<string, byte[]> _cache = new();

    public async Task<byte[]> SynthesizeSpeechAsync(HttpClient httpClient, string text, string voice = "nova")
    {
        string key = $"{voice}:{text}";
        if (_cache.TryGetValue(key, out var cached)) return cached;

        var modelsToTry = new[] { "tts-1", "tts-1-hd" };
        int retries = 3;

        foreach (var model in modelsToTry)
        {
            for (int i = 0; i < retries; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/audio/speech")
                {
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", _apiKey)
                    },
                    Content = new StringContent(JsonSerializer.Serialize(new
                    {
                        model = model,
                        input = text,
                        voice = voice,
                        response_format = "mp3"
                    }), Encoding.UTF8, "application/json")
                };

                try
                {
                    var response = await httpClient.SendAsync(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    {
                        if (response.Headers.TryGetValues("Retry-After", out var values) &&
                            int.TryParse(values.FirstOrDefault(), out int retryAfter))
                        {
                            await Task.Delay(retryAfter * 1000);
                        }
                        else
                        {
                            await Task.Delay(2000 * (i + 1));
                        }

                        continue;
                    }

                    response.EnsureSuccessStatusCode();
                    var audio = await response.Content.ReadAsByteArrayAsync();
                    _cache[key] = audio;
                    return audio;
                }
                catch
                {
                    if (i == retries - 1) break;
                    await Task.Delay(1000 * (i + 1));
                }
            }
        }

        throw new Exception("All models failed to generate speech after retries.");
    }
}