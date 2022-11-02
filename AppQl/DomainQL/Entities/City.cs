using DomainQl.Events;

namespace DomainQl.Entities;

public sealed class City
{
    private readonly List<Station> _stations = new();

    public long Id { get; }
    public string Name { get; }
    public IReadOnlyCollection<Station> Stations => _stations;

    public City(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddStation(AddStationEvent addStationEvent)
    {
        var find = _stations.FirstOrDefault(n => n.Id == addStationEvent.StationId);
        if (find is not null)
            return;
        
        _stations.Add(new Station(
            addStationEvent.StationId,
            addStationEvent.StationName,
            addStationEvent.GegrLat,
            addStationEvent.GegrLon,
            addStationEvent.AddressStreet));
    }
}