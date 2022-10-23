using Newtonsoft.Json;

namespace DomainGios.Entities;

public sealed class Commune
{
    [JsonProperty("communeName")] public string CommuneName { get; init; } = string.Empty;
    [JsonProperty("districtName")] public string DistrictName { get; init; } = string.Empty;
    [JsonProperty("provinceName")] public string ProvinceName { get; init; } = string.Empty;
}