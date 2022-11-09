using MediatR;

namespace Application.Mediator.Command;

public sealed class AddCommuteCommand : INotification
{
    
}

public sealed class AddCommuteCommandHandler : INotificationHandler<AddCommuteCommand>
{
    public async Task Handle(AddCommuteCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}