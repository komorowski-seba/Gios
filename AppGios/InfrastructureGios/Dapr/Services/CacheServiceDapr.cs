using ApplicationGios.Extensions;
using ApplicationGios.Interfaces;
using ApplicationGios.Models.Gios;
using ApplicationGios.Options;
using Dapr.Client;
using DomainGios.Entities;
using Microsoft.Extensions.Options;
using Shareed.Models;

namespace InfrastructureGios.Dapr.Services;

public class CacheServiceDapr : ICacheService
{
    private const string KeysStation = "keys_station";
    private const string KeyAirQuality = "key_air_quality";
    private readonly DaprClient _daprClient;
    private readonly DaprOptions _daprOptions;

    public CacheServiceDapr(DaprClient daprClient, IOptions<DaprOptions> daprOptions)
    {
        _daprClient = daprClient;
        _daprOptions = daprOptions.Value;
    }

    public async Task CacheStationsAsync(IEnumerable<Station> stations, CancellationToken cancellationToken)
    {
        var allStations = stations.Select(n => n.ToStationCache()).ToList();
        await _daprClient.SaveStateAsync(_daprOptions.StoryName, KeysStation, allStations, cancellationToken: cancellationToken);
    }

    public async Task<bool> CacheAirQualityIndexAsync(AirQualityIndexModel airQualityIndex, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GiosStationCacheModel>> GetAllStationsAsync(CancellationToken cancellationToken)
    {
        var result = await _daprClient.GetStateAsync<List<GiosStationCacheModel>>(_daprOptions.StoryName, KeysStation, cancellationToken: cancellationToken);
        return result ?? new List<GiosStationCacheModel>();
    }

    public async Task<AirQualityIndexModel?> GetLastAirQualityIndexAsync(long stationId, string airQualityType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

/*

    
    private readonly IDistributedCache _distributedCache;
    private readonly RedisOptions _redisOptions;

    public RedisCacheService(IDistributedCache distributedCache, IOptions<RedisOptions> redisOptions)
    {
        _distributedCache = distributedCache;
        _redisOptions = redisOptions.Value;
    }


    public async Task<List<GiosStationCacheModel>> GetAllStationsAsync(CancellationToken cancellationToken)
    {
        var stationsToByte = await _distributedCache.GetAsync($"{_redisOptions.VariableKey}_{KeyStation}", cancellationToken);
        if (stationsToByte is null)
            return new List<GiosStationCacheModel>();

        var result = JsonConvert.DeserializeObject<List<GiosStationCacheModel>>(Encoding.ASCII.GetString(stationsToByte));
        return result ?? new List<GiosStationCacheModel>();
    }

    public async Task<bool> CacheAirQualityIndexAsync(AirQualityIndexModel airQualityIndex, CancellationToken cancellationToken)
    {
        var lastAirQuality = await GetLastAirQualityIndexAsync(airQualityIndex.Id, airQualityIndex.AirQualityTypeName, cancellationToken);
        if (lastAirQuality is not null && lastAirQuality.Equals(airQualityIndex))
            return false;
        
        await _distributedCache.SetAsync(
            GetAirQualityIndexPath(airQualityIndex.Id, airQualityIndex.AirQualityTypeName), 
            SerializeData(airQualityIndex), 
            cancellationToken);
        return true;
    }
    
    public async Task<AirQualityIndexModel?> GetLastAirQualityIndexAsync(long stationId, string airQualityType, CancellationToken cancellationToken)
    {
        var airQualityByte = await _distributedCache
            .GetAsync(GetAirQualityIndexPath(stationId, airQualityType), cancellationToken);
        if (airQualityByte is null)
            return null;

        var result = JsonConvert.DeserializeObject<AirQualityIndexModel>(Encoding.ASCII.GetString(airQualityByte));
        return result;
    }

    private string GetAirQualityIndexPath(long stationId, string airQualityTypeName)
        => $"{_redisOptions.VariableKey}-{KeyAirQuality}-{stationId}-{airQualityTypeName}";
    
    private static byte[] SerializeData(object? value)
    {
        var serializeData = JsonConvert.SerializeObject(value);
        var stationToByte = Encoding.ASCII.GetBytes(serializeData);
        return stationToByte;
    }


*/