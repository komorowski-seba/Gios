using DomainQl.Common.Interfaces;

namespace DomainQl.Events;

public record AddQualityTestEvent(
    Guid Id,
    long StationId,
    DateTimeOffset CalcDate,
    DateTimeOffset DownloadDate,
    int So2IndexLevel,
    string So2IndexName,
    int No2IndexLevel,
    string No2IndexName,
    int Pm10IndexLevel,
    string Pm10IndexName,
    int Pm25IndexLevel,
    string Pm25IndexName,
    int O3IndexLevel,
    string O3IndexName) : IEvent;