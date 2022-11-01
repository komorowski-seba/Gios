using DomainQl.Events;

namespace DomainQl.Entities;

public sealed class Station
{
    public long Id { get; }
    public string StationName { get; }
    public string GegrLat { get; }
    public string GegrLon { get; }
    public string AddressStreet { get; }
    public AirQualityTest QualityTests { get; private set; }
    
    public Station(long id, string stationName, string gegrLat, string gegrLon, string addressStreet)
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
    }

    public void SetCurrentQualityTests(AddQualityTestEvent qualityTestEvent)
    {
        QualityTests = new AirQualityTest(
            qualityTestEvent.StationId,
            qualityTestEvent.CalcDate,
            qualityTestEvent.DownloadDate,
            qualityTestEvent.So2IndexLevel,
            qualityTestEvent.So2IndexName,
            qualityTestEvent.No2IndexLevel,
            qualityTestEvent.No2IndexName,
            qualityTestEvent.Pm10IndexLevel,
            qualityTestEvent.Pm10IndexName,
            qualityTestEvent.Pm25IndexLevel,
            qualityTestEvent.Pm25IndexName,
            qualityTestEvent.O3IndexLevel,
            qualityTestEvent.O3IndexName);
    }
}