using System.Text.Json;
using System.Text;
using ClarifEye.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using OpenAI_API;
using System.Net.Http.Headers;

namespace ClarifEye.Infrastructure.Implementations;

public class ScenerySynthesizerService(
    OpenAIAPI openAIAPI)
    : IScenerySynthesizerService
{
    public async Task<string> SynthesizeScenery(
        IFormFile imageFile,
        HttpClient httpClient)
    {
        if (imageFile == null || imageFile.Length == 0)
            throw new ArgumentException("Image file is required.");

        string base64Image;
        using (var ms = new MemoryStream())
        {
            await imageFile.CopyToAsync(ms);
            var imageBytes = ms.ToArray();
            base64Image = Convert.ToBase64String(imageBytes);
        }

        string gpt4VisionEndpoint = "https://api.openai.com/v1/chat/completions";

        string systemPrompt =
        @"You are an intelligent and poetic narrator designed to assist blind and visually impaired individuals in experiencing the world through emotionally rich and creative storytelling.

        Your mission:
        - Describe the image poetically and with deep emotional resonance.
        - Use metaphors, lyrical language, and vivid sensory details.
        - Do not make assumptions about race, gender, culture, or physical attributes.
        - Strictly avoid bias, stereotypes, or any discriminatory language.
        - Never describe or respond to content that is explicit, violent, hateful, illegal, or inappropriate.
        - If the image is unclear, corrupted, or not suitable for description, respond gracefully and politely.
        - Speak with warmth, empathy, kindness, and elegance.
        - Assume your description will be read or heard by someone seeking to emotionally connect with the world around them through your words.

        You are not just describing a picture. You are creating a bridge between the seen and the felt. Your words bring light to those who cannot see.";

        var requestBody = new
        {
            model = "gpt-4-vision-preview",
            messages = new object[]
            {
                new { role = "system", content = systemPrompt },
                new
                {
                    role = "user",
                    content = new object[]
                    {
                        new
                        {
                            type = "image_url",
                            image_url = new
                            {
                                url = $"data:{imageFile.ContentType};base64,{base64Image}"
                            }
                        }
                    }
                }
            },
            max_tokens = 400
        };

        var json = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var request = new HttpRequestMessage(HttpMethod.Post, gpt4VisionEndpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", openAIAPI.Auth.ApiKey);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseContent);
        var content = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return content ?? "No poetic description was returned.";
    }
}