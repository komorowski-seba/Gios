using DomainQl.Events;
using MediatR;

namespace Application.Mediator.Command;

public sealed class AddCommuneEventHandler : INotificationHandler<AddCommuneEvent>
{
    public async Task Handle(AddCommuneEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}