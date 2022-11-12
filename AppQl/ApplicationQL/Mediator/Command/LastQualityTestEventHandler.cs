using DomainQl.Events;
using MediatR;

namespace Application.Mediator.Command;

public sealed class LastQualityTestEventHandler : INotificationHandler<LastQualityTestEvent>
{
    public async Task Handle(LastQualityTestEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}