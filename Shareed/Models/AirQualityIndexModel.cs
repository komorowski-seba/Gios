using Newtonsoft.Json;

namespace Shareed.Models;

public sealed class AirQualityIndexModel
{
    [JsonProperty("id")] 
    public long Id { get; init; }

    [JsonProperty("airQualityTypeName", NullValueHandling = NullValueHandling.Ignore)] 
    public string AirQualityTypeName { get; init; } = string.Empty;
    
    [JsonProperty("calcDate", NullValueHandling=NullValueHandling.Ignore)] 
    public DateTimeOffset CalcDate { get; init; }
    
    [JsonProperty("sourceDataDate", NullValueHandling=NullValueHandling.Ignore)] 
    public DateTimeOffset SourceDataDate { get; init; }
    
    [JsonProperty("indexLevelValue")] 
    public int Value { get; init; }
    
    [JsonProperty("indexLevelName", NullValueHandling=NullValueHandling.Ignore)] 
    public string? IndexLevelName { get; init; }
    
    [JsonProperty("indexStatus", NullValueHandling=NullValueHandling.Ignore)] 
    public bool IndexStatus { get; init; }
    
    [JsonProperty("indexCrParam", NullValueHandling=NullValueHandling.Ignore)] 
    public string? IndexCrParam { get; init; }
    
    public bool Equals(AirQualityIndexModel? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Id == other.Id
               && AirQualityTypeName!.Equals(other.AirQualityTypeName)
               && Value == other.Value
               && other.CalcDate <= CalcDate;
    }

    public override bool Equals(object? obj)
        => Equals(obj as AirQualityIndexModel);

    public override int GetHashCode()
    {
        return $"{Id}-{AirQualityTypeName}".GetHashCode(StringComparison.InvariantCulture);
    }
}

public sealed class AirQualityCalculateValueTypes
{
    public const string SO2 = "so2";
    public const string PM10 = "pm10";
    public const string PM25 = "pm25";
    public const string O3 = "o3";
    public const string NO2 = "No2";
}