using DomainQl.Common.Interfaces;

namespace DomainQl.Common;

public abstract class Entitie : IEntitie
{
    [NonSerialized] private readonly List<IEvent> _events = new();

    public Guid Id { get; }

    public IEnumerable<IEvent> UncommittedEvents
    {
        get
        {
            var result = _events.ToArray();
            _events.Clear();
            return result;
        }
    }

    public void AddEvent(IEvent evt)
        => _events.Add(evt);
}