using DomainQl.Events;
using MediatR;

namespace Application.Mediator.Command;

public sealed class AddStationEventHandler : INotificationHandler<AddStationEvent>
{
    public async Task Handle(AddStationEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}