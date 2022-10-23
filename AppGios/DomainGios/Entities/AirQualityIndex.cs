using Newtonsoft.Json;

namespace DomainGios.Entities;

public sealed class AirQualityIndex
{
    [JsonProperty("id", NullValueHandling=NullValueHandling.Ignore)] public long Id { get; init; }
    
    // ST
    [JsonProperty("stIndexStatus", NullValueHandling=NullValueHandling.Ignore)] public bool StIndexStatus { get; init; }
    [JsonProperty("stIndexCrParam", NullValueHandling=NullValueHandling.Ignore)] public string StIndexCrParam { get; init; }
    [JsonProperty("stCalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset StCalcDate { get; init; }
    [JsonProperty("stIndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel StIndexLevel { get; init; }
    [JsonProperty("stSourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset StSourceDataDate { get; init; }

    // SO2
    [JsonProperty("so2CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset So2CalcDate { get; init; }
    [JsonProperty("so2IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel So2IndexLevel { get; init; }
    [JsonProperty("so2SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset So2SourceDataDate { get; init; }
        
    // NO2
    [JsonProperty("no2CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset No2CalcDate { get; init; }
    [JsonProperty("no2IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel No2IndexLevel { get; init; }
    [JsonProperty("no2SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset No2SourceDataDate { get; init; }
        
    // PM10
    [JsonProperty("pm10CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset Pm10CalcDate { get; init; }
    [JsonProperty("pm10IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel Pm10IndexLevel { get; init; }
    [JsonProperty("pm10SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset Pm10SourceDataDate { get; init; }
        
    // PM25
    [JsonProperty("pm25CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset Pm25CalcDate { get; init; }
    [JsonProperty("pm25IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel Pm25IndexLevel { get; init; }
    [JsonProperty("pm25SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTime Pm25SourceDataDate { get; init; }
        
    // O3
    [JsonProperty("o3CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset O3CalcDate { get; init; }
    [JsonProperty("o3IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel O3IndexLevel { get; init; }
    [JsonProperty("o3SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset O3SourceDataDate { get; init; }
}