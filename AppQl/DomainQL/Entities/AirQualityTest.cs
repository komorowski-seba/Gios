namespace DomainQl.Entities;

public sealed class AirQualityTest
{
    public Guid Id { get; }
    public long StationId { get; }
    public DateTimeOffset CalcDate { get; }
    public DateTimeOffset DownloadDate { get; }
    
    public int So2IndexLevel { get; }
    public string So2IndexName { get; }
    public int No2IndexLevel { get; }
    public string No2IndexName { get; }
    public int Pm10IndexLevel { get; }
    public string Pm10IndexName { get; }
    public int Pm25IndexLevel { get; }
    public string Pm25IndexName { get; }
    public int O3IndexLevel { get; }
    public string O3IndexName { get; }

    public AirQualityTest(
        long stationId,
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
        if (string.IsNullOrEmpty(so2IndexName))
            throw new ArgumentNullException(nameof(so2IndexName));
        if (string.IsNullOrEmpty(no2IndexName))
            throw new ArgumentNullException(nameof(no2IndexName));
        if (string.IsNullOrEmpty(pm10IndexName))
            throw new ArgumentNullException(nameof(pm10IndexName));
        if (string.IsNullOrEmpty(pm25IndexName))
            throw new ArgumentNullException(nameof(pm25IndexName));
        if (string.IsNullOrEmpty(o3IndexName))
            throw new ArgumentNullException(nameof(o3IndexName));
        
        Id = Guid.NewGuid();
        CalcDate = calcDate;
        DownloadDate = downloadDate;
        So2IndexLevel = so2IndexLevel;
        So2IndexName = so2IndexName;
        No2IndexLevel = no2IndexLevel;
        No2IndexName = no2IndexName;
        Pm10IndexLevel = pm10IndexLevel;
        Pm10IndexName = pm10IndexName;
        Pm25IndexLevel = pm25IndexLevel;
        Pm25IndexName = pm25IndexName;
        O3IndexLevel = o3IndexLevel;
        O3IndexName = o3IndexName;
            
        StationId = stationId;
    }
}