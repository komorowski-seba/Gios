using DomainQl.Common.Interfaces;
using DomainQl.Events;

namespace DomainQl.Entities;

public sealed class City : IEntitie
{
    private readonly List<Station> _stations = new();

    public long Id { get; }
    public string Name { get; }
    public Guid CommuneId { get; }
    public IReadOnlyCollection<Station> Stations => _stations;

    private City() {}
    
    public City(long id, string name, Guid communeId)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        
        Id = id;
        Name = name;
        CommuneId = CommuneId;
    }

    public Station AddStation(long id, long cityId, string stationName, string gegrLat, string gegrLon, string addressStreet)
    {
        var station = new Station(id, cityId, stationName, gegrLat, gegrLon, addressStreet);

        var city = _cities.FirstOrDefault(n => n.Id.Equals(cityId));
        if (city is null)
            throw new NullReferenceException(nameof(city));
        
        city.AddStation(station);
        AddEvent(new AddStationEvent(Id, cityId, id, stationName, gegrLat, gegrLon, addressStreet));
        return station;
    }
}