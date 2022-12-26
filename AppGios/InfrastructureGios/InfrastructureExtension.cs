using InfrastructureGios.Dapr;
using InfrastructureGios.Gios;
using InfrastructureGios.Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureGios;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHangfireServices(configuration);
        services.AddGiosServices();
        // services.AddKafkaPublishServices(configuration);
        // services.AddRedisServices(configuration);
        services.AddDaprServices();
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseHangfireConfiguration();
        app.UseDaprConfiguration();
        return app;
    }

}

// var state = JsonConvert.SerializeObject(new Hey
// {
//     Aaa = "abc",
//     Bbb = "Bbb"
// });
//     
// var client = new DaprClientBuilder().Build();
// await client.SaveStateAsync("statestore", Guid.NewGuid().ToString(), state);
// return " Next test ";