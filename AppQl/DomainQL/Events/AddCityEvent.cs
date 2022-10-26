using DomainQl.Common.Interfaces;

namespace DomainQl.Events;

public record AddCityEvent(Guid CommuneId, long CityId, string Name) : IEvent;