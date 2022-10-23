using DomainGios.Entities;
using Shareed.Models;

namespace ApplicationGios.Interfaces;

public interface IGiosService
{
    Task<IList<Station>?> GetAllStations(CancellationToken cancellationToken);
    Task<IEnumerable<AirQualityIndexModel>> GetStationAirQuality(long stationId);
}