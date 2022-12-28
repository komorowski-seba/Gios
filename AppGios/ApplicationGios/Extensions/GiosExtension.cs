using DomainGios.Entities;
using Shareed.Models;

namespace ApplicationGios.Extensions;

public static class GiosExtension
{
    public static StationModel ToSationModel(this Station station)
    {
        var result = new StationModel
        {
            Id = station.Id,
            GegrLat = station.GegrLat,
            GegrLon = station.GegrLon,
            StationName = station.StationName,
            AddressStreet = station.AddressStreet,
            
            CityId = station.City?.Id ?? -1,
            CityName = station.City?.Name ?? "[NULL]",
            
            CommuneName = station.City?.Commune?.CommuneName ?? "[NULL]",
            DistrictName = station.City?.Commune?.DistrictName ?? "[NULL]",
            ProvinceName = station.City?.Commune?.ProvinceName ?? "[NULL]"
        };
        return result;
    }

    public static ICollection<AirQualityIndexModel> ToAirQualityIndexModel(this AirQualityIndex airQualityIndex)
    {
        var result = new AirQualityIndexModel[]
        {
            new ()
            {
                Id = airQualityIndex.Id,
                AirQualityTypeName = AirQualityCalculateValueTypes.O3,
                CalcDate = airQualityIndex.O3CalcDate,
                SourceDataDate = airQualityIndex.O3SourceDataDate,
                Value = airQualityIndex.O3IndexLevel.Value,
                IndexLevelName = airQualityIndex.O3IndexLevel.IndexLevelName,
            },
            new ()
            {
                Id = airQualityIndex.Id,
                AirQualityTypeName = AirQualityCalculateValueTypes.NO2,
                CalcDate = airQualityIndex.No2CalcDate,
                SourceDataDate = airQualityIndex.No2SourceDataDate,
                Value = airQualityIndex.No2IndexLevel.Value,
                IndexLevelName = airQualityIndex.No2IndexLevel.IndexLevelName,
            },
            new ()
            {
                Id = airQualityIndex.Id,
                AirQualityTypeName = AirQualityCalculateValueTypes.PM10,
                CalcDate = airQualityIndex.Pm10CalcDate,
                SourceDataDate = airQualityIndex.Pm10SourceDataDate,
                Value = airQualityIndex.Pm10IndexLevel.Value,
                IndexLevelName = airQualityIndex.Pm10IndexLevel.IndexLevelName,
            },
            new ()
            {
                Id = airQualityIndex.Id,
                AirQualityTypeName = AirQualityCalculateValueTypes.PM25,
                CalcDate = airQualityIndex.Pm25CalcDate,
                SourceDataDate = airQualityIndex.Pm25SourceDataDate,
                Value = airQualityIndex.Pm25IndexLevel.Value,
                IndexLevelName = airQualityIndex.Pm25IndexLevel.IndexLevelName,
            },
            new ()
            {
                Id = airQualityIndex.Id,
                AirQualityTypeName = AirQualityCalculateValueTypes.SO2,
                CalcDate = airQualityIndex.So2CalcDate,
                SourceDataDate = airQualityIndex.So2SourceDataDate,
                Value = airQualityIndex.So2IndexLevel.Value,
                IndexLevelName = airQualityIndex.So2IndexLevel.IndexLevelName,
            },
        };
        return result;
    }
}