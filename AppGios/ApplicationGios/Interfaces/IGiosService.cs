using Shareed.Models;

namespace ApplicationGios.Interfaces;

public interface IGiosService
{
    Task<IList<StationModel>> GetAllStationsAsync(CancellationToken cancellationToken);
    Task<IEnumerable<AirQualityIndexModel>> GetStationAirQualityAsync(long stationId, CancellationToken cancellationToken);
}