using MediatR;

namespace Application.Mediator.Command;

public sealed class AddStationStateCommand : INotification
{
    // public AirTestDto AirTest { get; set; }
}

public sealed class AddStationStateCommandHandler : INotificationHandler<AddStationCommand>
{
    public async Task Handle(AddStationCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}