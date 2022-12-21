using ApplicationGios.Interfaces;
using MediatR;
using Shareed.Events;
using Shareed.Interfaces;

namespace ApplicationGios.Mediator.Commands;

public sealed class CheckStationStatusCommand : INotification
{
}

public sealed class CheckStationStatusHandler : INotificationHandler<CheckStationStatusCommand>
{
    // private readonly IGiosService _giosService;
    // private readonly IExternalEventService<StationStatusExtEvent> _externalEventService;
    // private readonly ICacheService _cacheService;

    public CheckStationStatusHandler()
        // IGiosService giosService, 
        // ICacheService cacheService, 
        // IExternalEventService<StationStatusExtEvent> externalEventService)
    {
        // _giosService = giosService;
        // _cacheService = cacheService;
        // _externalEventService = externalEventService;
    }

    public async Task Handle(CheckStationStatusCommand notification, CancellationToken cancellationToken)
    {
        // var allStations = await _cacheService.GetAllStationsAsync(cancellationToken);
        // foreach (var station in allStations)
        // {
        //     var allAirQuality = await _giosService.GetStationAirQuality(station.Id);
        //     foreach (var currentQuality in allAirQuality)
        //     {
        //         var isWrite = await _cacheService.CacheAirQualityIndexAsync(currentQuality, cancellationToken);
        //         if (isWrite)
        //             await _externalEventService.Publish(new StationStatusExtEvent {Status = currentQuality});
        //     }            
        // }
    }
}