using DomainQl.Events;

namespace DomainQl.Entities;

public sealed class Commune : IEquatable<Commune>
{
    private readonly List<City> _cities = new();

    public Guid Id { get; }
    public string CommuneName { get; }
    public string DistrictName { get; }
    public string ProvinceName { get; }
    public IReadOnlyCollection<City> Cities => _cities;

    private Commune() { }

    public Commune(AddCommuneEvent @event)
    {
        Id = @event.CommuneId;
        CommuneName = @event.CommuneName;
        DistrictName = @event.DistrictName;
        ProvinceName = @event.ProvinceName;
    }

    public void ApplyAddCityEvent(AddCityEvent @event)
    {
        if (_cities.Any(n => n.Id == @event.CityId))
            return;
        
        _cities.Add(new City(@event.CityId, @event.Name));
    }

    public void ApplyAddStationEvent(AddStationEvent @event)
    {
        _cities
            .FirstOrDefault(n => n.Id == @event.CityId)?
            .AddStation(@event);
    }

    public void ApplyLastQualityTestEvent(LastQualityTestEvent lastQualityTestEvent)
    {
        _cities
            .FirstOrDefault(n => n.Id == lastQualityTestEvent.CityId)?
            .Stations
            .FirstOrDefault(n => n.Id == lastQualityTestEvent.StationId)?
            .SetCurrentQualityTests(lastQualityTestEvent);
    }

    public bool Equals(Commune? other)
    {
        return other is not null  
               && CommuneName.Equals(other.CommuneName)
               && DistrictName.Equals(other.DistrictName)
               && ProvinceName.Equals(other.ProvinceName);
    }

    public override bool Equals(object? obj)
        => Equals(obj as Commune);

    public override int GetHashCode()
        => $"{CommuneName}_{DistrictName}_{ProvinceName}".GetHashCode(StringComparison.InvariantCulture);
}