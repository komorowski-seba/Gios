using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationGios;

public static class ApplicationGiosExtension
{
    public static IServiceCollection ApplicationGiosServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}