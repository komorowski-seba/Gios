using DomainQL.Common.Exceptions;
using DomainQl.Common.Interfaces;
using DomainQl.Events;

namespace DomainQl.Entities;

public sealed class Commune : IAggregate
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
            throw new CityExistException($"City: {addCityEvent.Name}; {addCityEvent.CityId}");
        
        _cities.Add(new City(addCityEvent.CityId, addCityEvent.Name));
    }

    public void Apply(AddStationEvent addStationEvent)
    {
    }
}