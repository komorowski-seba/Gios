using DomainQl.Entities;
using DomainQl.Events;

namespace Infrastructure.Marten.Projections;

public class CommuneProjection : SingleStreamAggregation<Commune>
{
    public Commune Create(AddCommuneEvent @event) 
        => new(@event);

    public void Apply(AddCityEvent @event, Commune commune) 
        => commune.ApplyAddCityEvent(@event);
}