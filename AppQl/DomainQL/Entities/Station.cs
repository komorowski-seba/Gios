using DomainQl.Common.Interfaces;

namespace DomainQl.Entities;

public sealed class Station : IEntitie
{
    private readonly List<AirQualityTest> _qualityTests = new();
    
    public long Id { get; }
    public string StationName { get; }
    public string GegrLat { get; }
    public string GegrLon { get; }
    public string AddressStreet { get; }
    public long CityId { get; }
    public IReadOnlyCollection<AirQualityTest> QualityTests => _qualityTests;

    private Station() { }
    
    public Station(long id, long cityId, string stationName, string gegrLat, string gegrLon, string addressStreet)
    {
        if (string.IsNullOrEmpty(stationName))
            throw new ArgumentNullException(nameof(stationName));
        if (string.IsNullOrEmpty(gegrLat))
            throw new ArgumentNullException(nameof(gegrLat));
        if (string.IsNullOrEmpty(gegrLon))
            throw new ArgumentNullException(nameof(gegrLon));

        Id = id;
        StationName = stationName;
        GegrLat = gegrLat;
        GegrLon = gegrLon;
        AddressStreet = string.IsNullOrEmpty(addressStreet) ? string.Empty : addressStreet;
        CityId = cityId;
    }

    public Station AddQualityTests(
        long cityId,
        long staionId,
        DateTimeOffset calcDate,
        DateTimeOffset downloadDate,
        int so2IndexLevel,
        string so2IndexName,
        int no2IndexLevel,
        string no2IndexName,
        int pm10IndexLevel,
        string pm10IndexName,
        int pm25IndexLevel,
        string pm25IndexName,
        int o3IndexLevel,
        string o3IndexName)
    {
        var station = _cities
            .FirstOrDefault(n => n.Id.Equals(cityId))?
            .Stations
            .FirstOrDefault(n => n.Id.Equals(staionId));
        
        if (station is null)
            throw new NullReferenceException("Station or City not found");
        
        var qualityTest = new AirQualityTest(
            staionId,
            calcDate,
            downloadDate,
            so2IndexLevel,
            so2IndexName,
            no2IndexLevel,
            no2IndexName,
            pm10IndexLevel,
            pm10IndexName,
            pm25IndexLevel,
            pm25IndexName,
            o3IndexLevel,
            o3IndexName);
        
        station.AddQualityTest(qualityTest);
        AddEvent(new AddQualityTestEvent(
            Id,
            staionId,
            calcDate,
            downloadDate,
            so2IndexLevel,
            so2IndexName,
            no2IndexLevel,
            no2IndexName,
            pm10IndexLevel,
            pm10IndexName,
            pm25IndexLevel,
            pm25IndexName,
            o3IndexLevel,
            o3IndexName));
        return station;
    }

}