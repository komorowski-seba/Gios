using Newtonsoft.Json;

namespace Shareed.Models;

public class StationModel
{
    [JsonProperty("id")] public long Id { get; init; }
    [JsonProperty("stationName")] public string StationName { get; init; }
    [JsonProperty("gegrLat")] public string GegrLat { get; init; }
    [JsonProperty("gegrLon")] public string GegrLon { get; init; }
    [JsonProperty("addressStreet")] public string AddressStreet { get; init; }
    
    [JsonProperty("city_id")] public long CityId { get; init; }
    [JsonProperty("city_name")] public string CityName { get; init; }
    
    [JsonProperty("communeName")] public string CommuneName { get; init; }
    [JsonProperty("districtName")] public string DistrictName { get; init; }
    [JsonProperty("provinceName")] public string ProvinceName { get; init; }
}