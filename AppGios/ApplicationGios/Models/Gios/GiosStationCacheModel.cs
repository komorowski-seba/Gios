using Newtonsoft.Json;

namespace ApplicationGios.Models.Gios;

public class GiosStationCacheModel : IEquatable<GiosStationCacheModel>
{
    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("gegrLat")] public string? GegrLat { get; set; }
    [JsonProperty("gegrLon")] public string? GegrLon { get; set; }
    [JsonProperty("stationName")] public string? StationName { get; set; }
    [JsonProperty("cityName")] public string? City { get; set; }
    [JsonProperty("provinceName")] public string? Province { get; set; }

    public bool Equals(GiosStationCacheModel? cache)
    {
        if (cache is null)
            return false;

        return Id == cache.Id;
    }

    public override bool Equals(object? obj)
        => Equals(obj as GiosStationCacheModel);

    public override int GetHashCode()
    {
        return (int)Id;
    }
}