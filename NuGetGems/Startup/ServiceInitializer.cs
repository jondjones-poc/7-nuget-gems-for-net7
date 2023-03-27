namespace NuGetGems;

public static partial class ServiceInitializer
{
    public static IServiceCollection RegisterApplicationServices(
                                        this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddFusionCache();

        RegisterSwagger(services);
        return services;
    }

    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}

