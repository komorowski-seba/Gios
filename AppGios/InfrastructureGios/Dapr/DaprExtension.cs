using ApplicationGios.Interfaces;
using InfrastructureGios.Dapr.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureGios.Dapr;

public static class DaprExtension
{
    public static IServiceCollection AddDaprServices(this IServiceCollection services)
    {
        services.AddDaprClient();
        services.AddScoped<ICacheService, CacheServiceDapr>();
        return services;
    }

    public static IApplicationBuilder UseDaprConfiguration(this IApplicationBuilder app)
    {
        app.UseCloudEvents();
        return app;
    }
}