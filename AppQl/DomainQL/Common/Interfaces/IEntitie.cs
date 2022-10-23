namespace DomainQl.Common.Interfaces;

public interface IEntitie
{
    Guid Id { get; }
    IEnumerable<IEvent> UncommittedEvents { get; }
    void AddEvent(IEvent evt);
}