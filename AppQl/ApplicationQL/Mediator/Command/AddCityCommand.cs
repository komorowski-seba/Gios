using MediatR;

namespace Application.Mediator.Command;

public sealed class AddCityCommand : INotification
{
    
}

public sealed class AddCityCommandHandler : INotificationHandler<AddCityCommand>
{
    public async Task Handle(AddCityCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}