using Shareed.Models;

namespace ApplicationGios.Interfaces;

public interface ICacheService
{
    Task CacheStationsAsync(IEnumerable<StationModel> stations, CancellationToken cancellationToken);
    Task<bool> CacheAirQualityIndexAsync(AirQualityIndexModel airQualityIndex, CancellationToken cancellationToken);
    Task<List<StationModel>> GetAllStationsAsync(CancellationToken cancellationToken);
    Task<AirQualityIndexModel?> GetLastAirQualityIndexAsync(long stationId, string airQualityType, CancellationToken cancellationToken);
}