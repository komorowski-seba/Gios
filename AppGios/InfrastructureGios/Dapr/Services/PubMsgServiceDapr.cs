using ApplicationGios.Interfaces;
using ApplicationGios.Options;
using Dapr.Client;
using Microsoft.Extensions.Options;
using Shareed.Models;

namespace InfrastructureGios.Dapr.Services;

public class PubMsgServiceDapr : IPubMsgService
{
    private readonly DaprClient _daprClient;
    private readonly DaprOptions _daprOptions;

    public PubMsgServiceDapr(DaprClient daprClient, IOptions<DaprOptions> daprOptions)
    {
        _daprClient = daprClient;
        _daprOptions = daprOptions.Value;
    }

    public async Task PublishStationAsync(StationModel stationModel, CancellationToken cancellationToken)
    {
        await _daprClient.PublishEventAsync(_daprOptions.PubsubName, _daprOptions.Topic, stationModel, cancellationToken);
    }
}