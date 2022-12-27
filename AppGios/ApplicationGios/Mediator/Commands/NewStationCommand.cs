using ApplicationGios.Extensions;
using ApplicationGios.Interfaces;
using MediatR;
using Shareed.Events;
using Shareed.Interfaces;

namespace ApplicationGios.Mediator.Commands;

public sealed class NewStationCommand : INotification
{
}

public sealed class NewStationHandler : INotificationHandler<NewStationCommand>
{
    private readonly IGiosService _giosService;
    private readonly ICacheService _cacheService;
    // private readonly IExternalEventService<NewStationExtEvent> _externalEventService;

    public NewStationHandler(
        IGiosService giosService, 
        // IExternalEventService<NewStationExtEvent> externalEventService, 
        ICacheService cacheService)
    {
        _giosService = giosService;
        _cacheService = cacheService;
        // _externalEventService = externalEventService;
    }

    public async Task Handle(NewStationCommand notification, CancellationToken cancellationToken)
    {
        var allStations = await _giosService.GetAllStationsAsync(cancellationToken);
        await _cacheService.CacheStationsAsync(allStations, cancellationToken);
        // foreach (var station in allStations)
        // {
        //     await _externalEventService.Publish(new NewStationExtEvent {NewStation = station.ToSationModel()});
        // }
    }
}