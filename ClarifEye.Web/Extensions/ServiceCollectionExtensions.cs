using ClarifEye.Data.Models;
using ClarifEye.Data.Repository.Interfaces;
using ClarifEye.Infrastructure.Implementations;
using ClarifEye.Infrastructure.Interfaces;

namespace ClarifEye.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IRepository<Choice, int>, Repository<Choice, int>>();
        services.AddScoped<IRepository<ChoiceAnswer, object>, Repository<ChoiceAnswer, object>>();
        services.AddScoped<IRepository<ClarUser, string>, Repository<ClarUser, string>>();
        services.AddScoped<IRepository<MultipleChoiceQuestion, int>, Repository<MultipleChoiceQuestion, int>>();
        services.AddScoped<IRepository<ScaleAnswer, int>, Repository<ScaleAnswer, int>>();
        services.AddScoped<IRepository<ScaleQuestion, int>, Repository<ScaleQuestion, int>>();
        services.AddScoped<IRepository<YesNoAnswer, int>, Repository<YesNoAnswer, int>>();
        services.AddScoped<IRepository<YesNoQuestion, int>, Repository<YesNoQuestion, int>>();

        return services;
    }

    public static IServiceCollection RegisterUserDefinedServices(
        this IServiceCollection services)
    {
        services.AddScoped<IDetectorService, DetectorService>();
        services.AddScoped<ITextToSpeechService, TextToSpeechService>();
        services.AddScoped<ITranslatorService, TranslatorService>();
        services.AddScoped<IScenerySynthesizerService, ScenerySynthesizerService>();

        return services;
    }
}
