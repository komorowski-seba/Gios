using Infrastructure.Elastic;
using Infrastructure.Kafka;
using Infrastructure.Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddWebQlInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKafkaConsumerServices();
        services.AddMartenServices(configuration);
        services.AddElasticServices(configuration);
        return services;
    }
}