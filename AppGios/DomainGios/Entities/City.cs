using Newtonsoft.Json;

namespace DomainGios.Entities;

public sealed class City
{
    [JsonProperty("id")] public long Id { get; init; }
    [JsonProperty("name")] public string Name { get; init; } = string.Empty;
    [JsonProperty("commune")] public Commune? Commune { get; init; }
}