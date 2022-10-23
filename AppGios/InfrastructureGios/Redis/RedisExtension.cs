using ApplicationGios.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureGios.Redis;

public static class RedisExtension
{
    public static IServiceCollection AddRedisServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDistributedRedisCache(option =>
        {
            option.Configuration = configuration.GetSection("Redis:ConfigurationHost").Value;
            option.InstanceName = configuration.GetSection("Redis:InstanceName").Value; 
        });
        services.AddScoped<ICacheService, RedisCacheService>();
        return services;
    }
}