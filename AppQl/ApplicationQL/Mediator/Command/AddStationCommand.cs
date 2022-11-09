using MediatR;

namespace Application.Mediator.Command;

public sealed class AddStationCommand : INotification
{
    // public Station NewStation { get; set; }
}

public sealed class AddStationCommandHandler : INotificationHandler<AddStationCommand>
{
    public async Task Handle(AddStationCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}