using Shareed.Models;

namespace ApplicationGios.Interfaces;

public interface IPubMsgService
{
    Task PublishStationAsync(StationModel stationModel, CancellationToken cancellationToken);
}