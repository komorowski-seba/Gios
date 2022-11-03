using Marten.Events.Aggregation;

namespace Infrastructure.Marten.Projections;

public class StationEventsProjection : AggregateProjection<StationStorageEvent>
{
    public StationEventsProjection()
    {
        ProjectEvent<AddStationEvent>((i, e) => i.Apply(e));
    }
}