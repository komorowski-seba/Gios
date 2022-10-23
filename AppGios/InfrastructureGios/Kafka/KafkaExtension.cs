using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shareed.Interfaces;

namespace InfrastructureGios.Kafka;

public static class KafkaExtension
{
    public static IServiceCollection AddKafkaPublishServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IExternalEventService<>), typeof(KafkaExternalEventPushService<>));
        return services;
    }
}