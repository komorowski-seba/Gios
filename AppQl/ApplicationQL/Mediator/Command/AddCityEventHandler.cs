using Application.Interfaces;
using DomainQl.Events;
using MediatR;

namespace Application.Mediator.Command;

public sealed class AddCityEventHandler : INotificationHandler<AddCityEvent>
{
    private readonly IEventsStoreDb _eventsStore;

    public AddCityEventHandler(IEventsStoreDb eventsStore)
    {
        _eventsStore = eventsStore;
    }

    public async Task Handle(AddCityEvent notification, CancellationToken cancellationToken)
    {
        await _eventsStore.AppendEventAsync(notification, cancellationToken);
    }
}