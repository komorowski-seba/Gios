using ApplicationGios.Interfaces;
using MediatR;

namespace ApplicationGios.Mediator.Commands;

public sealed class NewStationCommand : INotification
{
}

public sealed class NewStationHandler : INotificationHandler<NewStationCommand>
{
    private readonly IGiosService _giosService;
    private readonly ICacheService _cacheService;
    private readonly IPubMsgService _pubMsgService;

    public NewStationHandler(IGiosService giosService, ICacheService cacheService, IPubMsgService pubMsgService)
    {
        _giosService = giosService;
        _cacheService = cacheService;
        _pubMsgService = pubMsgService;
    }

    public async Task Handle(NewStationCommand notification, CancellationToken cancellationToken)
    {
        var allStations = await _giosService.GetAllStationsAsync(cancellationToken);
        await _cacheService.CacheStationsAsync(allStations, cancellationToken);
        foreach (var station in allStations)
        {
            await _pubMsgService.PublishStationAsync(station, cancellationToken);
        }
    }
}