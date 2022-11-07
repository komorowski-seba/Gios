using MediatR;

namespace DomainQl.Common.Interfaces;

public interface IEvent : INotification
{
    Guid CommuneId { get; }
}