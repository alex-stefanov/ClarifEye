using ClarifEye.Common.Enums;

namespace ClarifEye.Infrastructure.Interfaces;

public interface ITranslatorService
{
    Task<string> TranslateTextAsync(string text, Language language);
}
