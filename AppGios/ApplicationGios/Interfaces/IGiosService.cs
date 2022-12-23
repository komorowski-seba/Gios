using DomainGios.Entities;
using Shareed.Models;

namespace ApplicationGios.Interfaces;

public interface IGiosService
{
    Task<IList<Station>> GetAllStationsAsync(CancellationToken cancellationToken);
    Task<IEnumerable<AirQualityIndexModel>> GetStationAirQualityAsync(long stationId, CancellationToken cancellationToken);
}