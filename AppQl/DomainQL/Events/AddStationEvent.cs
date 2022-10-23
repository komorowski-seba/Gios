using DomainQl.Common.Interfaces;

namespace DomainQl.Events;

public record AddStationEvent(
    Guid Id, 
    long CityId,
    long StationId,
    string StationName,
    string GegrLat,
    string GegrLon,
    string AddressStreet) : IEvent;