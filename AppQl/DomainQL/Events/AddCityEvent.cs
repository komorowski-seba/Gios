using DomainQl.Common.Interfaces;

namespace DomainQl.Events;

public record AddCityEvent(Guid Id, long CityId, string Name) : IEvent;