using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Kafka;

public static class KafkaExtensions
{
    public static IServiceCollection AddKafkaConsumerServices(this IServiceCollection services)
    {
        // services.AddHostedService<KafkaExternalEventConsumerService<NewStationExtEvent>>();
        // services.AddHostedService<KafkaExternalEventConsumerService<StationStatusExtEvent>>();
        return services;
    }
}