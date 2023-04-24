using Forge.OpenAI;
using NuGetGems.Startup;

namespace NuGetGems;

public static partial class ServiceInitializer
{
    public static IServiceCollection RegisterApplicationServices(
                                        this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddFusionCache();

        services.AddForgeOpenAI(options => {
            options.AuthenticationInfo = MyStringHelper.MY_API_KEY;
        });

        RegisterSwagger(services);
        return services;
    }

    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}

