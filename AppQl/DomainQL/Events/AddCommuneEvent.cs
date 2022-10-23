using DomainQl.Common.Interfaces;

namespace DomainQl.Events;

public record AddCommuneEvent(Guid Id, string CommuneName, string DistrictName, string ProvinceName) : IEvent, IEventStartStream;