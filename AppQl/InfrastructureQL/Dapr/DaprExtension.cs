using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureQL.Dapr;

public static class DaprExtension
{
    public static IServiceCollection AddDaprServices(this IServiceCollection services)
    {
        services.AddDaprClient();
        // services.AddScoped<ICacheService, CacheServiceDapr>();
        // services.AddScoped<IPubMsgService, PubMsgServiceDapr>();
        return services;
    }

    public static IApplicationBuilder UseDaprConfiguration(this IApplicationBuilder app)
    {
        app.UseCloudEvents();
        return app;
    }
}