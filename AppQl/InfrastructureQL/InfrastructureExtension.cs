using InfrastructureQL.Elastic;
using InfrastructureQL.Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureQL;

public static class InfrastructureExtension
{
    public static IServiceCollection AddWebQlInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMartenServices(configuration);
        services.AddElasticServices(configuration);
        return services;
    }
}