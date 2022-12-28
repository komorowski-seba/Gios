using Newtonsoft.Json;

namespace Shareed.Models;

public class StationModel
{
    [JsonProperty("id")] public long Id { get; init; }
    [JsonProperty("stationName")] public string StationName { get; init; } = string.Empty;
    [JsonProperty("gegrLat")] public string GegrLat { get; init; } = string.Empty;
    [JsonProperty("gegrLon")] public string GegrLon { get; init; } = string.Empty;
    [JsonProperty("addressStreet")] public string AddressStreet { get; init; } = string.Empty;
    
    [JsonProperty("city_id")] public long CityId { get; init; }
    [JsonProperty("city_name")] public string CityName { get; init; } = string.Empty;

    [JsonProperty("communeName")] public string CommuneName { get; init; } = string.Empty;
    [JsonProperty("districtName")] public string DistrictName { get; init; } = string.Empty;
    [JsonProperty("provinceName")] public string ProvinceName { get; init; } = string.Empty;
}