﻿using Application.Interfaces;
using Application.Options;
using Infrastructure.Marten.Projections;
using Infrastructure.Marten.Services;
using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;

namespace Infrastructure.Marten;

public static class MartenExtension
{
    public static IServiceCollection AddMartenServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMarten(n =>
        {
            n.Connection(configuration.GetConnectionString("Marten"));
            n.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
            n.DatabaseSchemaName = configuration.GetSection($"Marten:{nameof(MartenOptions.DBSchemaName)}").Value;
            n.Events.DatabaseSchemaName = configuration.GetSection($"Marten:{nameof(MartenOptions.EventSchemaName)}").Value;
            
            n.Projections.Add<CommuneProjection>();
        });
        services.AddScoped<IEventsStoreDb, MartensEventsStoreDb>();
        return services;
    }
}