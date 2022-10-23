using System.Text;
using ApplicationGios.Extensions;
using ApplicationGios.Interfaces;
using ApplicationGios.Models.Gios;
using ApplicationGios.Options;
using DomainGios.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shareed.Models;

namespace InfrastructureGios.Redis;

public sealed class RedisCacheService : ICacheService
{
    private const string KeyStation = "key_station";
    private const string KeyAirQuality = "key_air_quality";
    
    private readonly IDistributedCache _distributedCache;
    private readonly RedisOptions _redisOptions;

    public RedisCacheService(IDistributedCache distributedCache, IOptions<RedisOptions> redisOptions)
    {
        _distributedCache = distributedCache;
        _redisOptions = redisOptions.Value;
    }

    public async Task CacheStationsAsync(IEnumerable<Station> stations, CancellationToken cancellationToken)
    {
        var stationsCase = stations.Select(n => n.ToStationCache()).ToList();
        var allStationCase = await GetAllStationsAsync(cancellationToken);
        var difference = stationsCase.Except(allStationCase).ToList();
        
        if (!difference.Any())
            return;
        
        allStationCase.AddRange(difference);
        await _distributedCache.SetAsync(
            $"{_redisOptions.VariableKey}_{KeyStation}", 
            SerializeData(allStationCase), 
            cancellationToken);
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
}