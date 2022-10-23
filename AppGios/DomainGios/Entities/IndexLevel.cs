using Newtonsoft.Json;

namespace DomainGios.Entities;

public sealed class IndexLevel
{
    [JsonProperty("id")] public int Value { get; init; }
    [JsonProperty("indexLevelName")] public string IndexLevelName { get; init; }
}