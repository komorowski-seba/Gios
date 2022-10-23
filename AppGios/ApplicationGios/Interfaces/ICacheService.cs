using ApplicationGios.Models.Gios;
using DomainGios.Entities;
using Shareed.Models;

namespace ApplicationGios.Interfaces;

public interface ICacheService
{
    Task CacheStationsAsync(IEnumerable<Station> stations, CancellationToken cancellationToken);
    Task<bool> CacheAirQualityIndexAsync(AirQualityIndexModel airQualityIndex, CancellationToken cancellationToken);
    Task<List<GiosStationCacheModel>> GetAllStationsAsync(CancellationToken cancellationToken);
    Task<AirQualityIndexModel?> GetLastAirQualityIndexAsync(long stationId, string airQualityType, CancellationToken cancellationToken);
}