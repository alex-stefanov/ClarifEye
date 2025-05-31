using ClarifEye.Infrastructure.Implementations;
using ClarifEye.Infrastructure.Interfaces;

namespace ClarifEye.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        //services.AddScoped<IRepository<Crop, string>, Repository<Crop, string>>();

        return services;
    }

    public static IServiceCollection RegisterUserDefinedServices(
        this IServiceCollection services)
    {
        services.AddScoped<IDetectorService, DetectorService>();

        return services;
    }
}
