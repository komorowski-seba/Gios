namespace DomainQl.Entities;

public sealed class City
{
    private readonly List<Station> _stations = new();

    public long Id { get; }
    public string Name { get; }
    public IReadOnlyCollection<Station> Stations => _stations;

    private City() {}
    
    public City(long id, string name)
    {
    }
}