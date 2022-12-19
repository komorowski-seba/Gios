using ApplicationGios.Interfaces;
using ApplicationGios.Mediator.Commands;
using Hangfire;
using MediatR;

namespace InfrastructureGios.Hangfire;

public class HangfireJobsService : IHangfireJobsService
{
    private readonly IMediator _mediator;

    public HangfireJobsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    [JobDisplayName("AllStationsJob_{0}"), AutomaticRetry(Attempts = 0)]
    public void AllStationJob()
    {
        // _mediator.Publish(new NewStationCommand()).Wait();
    }

    [JobDisplayName("AllStationsStatus_{0}"), AutomaticRetry(Attempts = 0)]
    public void AllStationsStatusJob()
    {
        // _mediator.Publish(new CheckStationStatusCommand()).Wait();
    }
}