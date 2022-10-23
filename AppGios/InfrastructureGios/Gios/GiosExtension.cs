using ApplicationGios.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureGios.Gios;

public static class GiosExtension
{
    public static IServiceCollection AddGiosServices(this IServiceCollection services)
    {
        services.AddScoped<IGiosService, GiosService>();
        return services;
    }
}