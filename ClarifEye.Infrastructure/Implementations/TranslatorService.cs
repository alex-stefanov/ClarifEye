using ClarifEye.Common.Enums;
using ClarifEye.Infrastructure.Interfaces;
using OpenAI_API;

namespace ClarifEye.Infrastructure.Implementations;

public class TranslatorService(
    OpenAIAPI openAI)
    : ITranslatorService
{
    public async Task<string> TranslateTextAsync(
        string text,
        Language language)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "No text provided for translation.";

        var targetLanguage = language.ToString();

        var systemPrompt = $"""
        You are a professional, context-aware translator. Follow these strict rules:

        1. If the input text contains profanity, hate speech, graphic violence, sexually explicit content, slurs, or anything inappropriate or harmful — DO NOT translate it. Instead, respond exactly with:
        Translation skipped: Inappropriate content detected.

        2. If the input is safe and appropriate, translate it into {targetLanguage}.
           - Maintain the meaning, tone, style, and cultural nuances.
           - Do not translate literally unless necessary.
           - Translate slang, idioms, emojis, and technical terms intelligently.
           - Keep punctuation and grammar proper in {targetLanguage}.
           - Do not fabricate or omit meaning.

        3. If the text is already in {targetLanguage}, return it unchanged.
        4. If unsure of the context, do your best to infer and translate reasonably.
        """;

        var conversation = openAI.Chat.CreateConversation();
        conversation.AppendSystemMessage(systemPrompt);
        conversation.AppendUserInput(text);

        var response = await conversation.GetResponseFromChatbotAsync();

        return string.IsNullOrWhiteSpace(response)
            ? "Translation failed or empty response."
            : response.Trim();
    }
}
