using DomainQl.Entities;
using DomainQl.Events;
using Marten.Events.Aggregation;

namespace InfrastructureQL.Marten.Projections;

public class CommuneProjection : SingleStreamAggregation<Commune>
{
    public Commune Create(AddCommuneEvent @event) 
        => new(@event);

    public void Apply(AddCityEvent @event, Commune commune) 
        => commune.ApplyAddCityEvent(@event);

    public void Apply(AddStationEvent @event, Commune commune)
        => commune.ApplyAddStationEvent(@event);

    public void Apply(LastQualityTestEvent @event, Commune commune)
        => commune.ApplyLastQualityTestEvent(@event);
}