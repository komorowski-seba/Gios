using DomainQl.Common.Interfaces;
using DomainQl.Events;

namespace DomainQl.Entities;

public sealed class Commune : IAggregate, IEquatable<Commune>
{
    private readonly List<City> _cities = new();

    public Guid Id { get; }
    public string CommuneName { get; }
    public string DistrictName { get; }
    public string ProvinceName { get; }
    public IReadOnlyCollection<City> Cities => _cities;

    private Commune() { }

    public Commune(AddCommuneEvent addCommuneEvent)
    {
        Id = addCommuneEvent.Id;
        CommuneName = addCommuneEvent.CommuneName;
        DistrictName = addCommuneEvent.DistrictName;
        ProvinceName = addCommuneEvent.ProvinceName;
    }

    public void Apply(AddCityEvent addCityEvent)
    {
        if (_cities.Any(n => n.Id == addCityEvent.CityId))
            return;
        
        _cities.Add(new City(addCityEvent.CityId, addCityEvent.Name));
    }

    public void Apply(AddStationEvent addStationEvent)
    {
        _cities
            .FirstOrDefault(n => n.Id == addStationEvent.CityId)?
            .AddStation(addStationEvent);
    }

    public void Apply(AddQualityTestEvent addQualityTestEvent)
    {
        _cities
            .FirstOrDefault(n => n.Id == addQualityTestEvent.CityId)?
            .Stations
            .FirstOrDefault(n => n.Id == addQualityTestEvent.StationId)?
            .SetCurrentQualityTests(addQualityTestEvent);
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