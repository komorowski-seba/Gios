﻿using ApplicationGios.Interfaces;
using ApplicationGios.Options;
using Dapr.Client;
using Shareed.Models;

namespace InfrastructureGios.Dapr.Services;

public class PubMsgServiceDapr : IPubMsgService
{
    private readonly DaprClient _daprClient;
    private readonly DaprOptions _daprOptions;


    public PubMsgServiceDapr(DaprClient daprClient, DaprOptions daprOptions)
    {
        _daprClient = daprClient;
        _daprOptions = daprOptions;
    }

    public async Task PublishStationAsync(StationModel stationModel, CancellationToken cancellationToken)
    {
        
    }
}