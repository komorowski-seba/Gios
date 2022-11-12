using DomainQl.Common.Interfaces;

namespace Application.Interfaces;

public interface IEventsStoreDb
{
    Task AppendEventAsync(IEvent evt, CancellationToken cancellationToken);
}