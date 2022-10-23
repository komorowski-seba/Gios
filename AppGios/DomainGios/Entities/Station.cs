using Newtonsoft.Json;

namespace DomainGios.Entities;

public sealed class Station
{
    [JsonProperty("id")] public long Id { get; init; }
    [JsonProperty("stationName")] public string StationName { get; init; }
    [JsonProperty("gegrLat")] public string GegrLat { get; init; }
    [JsonProperty("gegrLon")] public string GegrLon { get; init; }
    [JsonProperty("city")] public City? City { get; init; }
    [JsonProperty("addressStreet")] public string AddressStreet { get; init; }
}