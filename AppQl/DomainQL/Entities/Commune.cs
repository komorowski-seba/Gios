using DomainQl.Common;
using DomainQl.Common.Interfaces;
using DomainQl.Events;

namespace DomainQl.Entities;

public sealed class Commune : Entitie, IAggregate
{
    private readonly List<City> _cities = new();

    public Guid Id { get; }
    public string CommuneName { get; }
    public string DistrictName { get; }
    public string ProvinceName { get; }
    public IReadOnlyCollection<City> Cities => _cities;

    private Commune() { }
    
    public Commune(string communeName, string districtName, string provinceName)
    {
        if (string.IsNullOrEmpty(communeName)) throw new ArgumentNullException(nameof(communeName));
        if (string.IsNullOrEmpty(districtName)) throw new ArgumentNullException(nameof(districtName));
        if (string.IsNullOrEmpty(provinceName)) throw new ArgumentNullException(nameof(provinceName));
        
        Id = Guid.NewGuid();
        CommuneName = communeName;
        DistrictName = districtName;
        ProvinceName = provinceName;
        
        AddEvent(new AddCommuneEvent(Id, CommuneName, DistrictName, ProvinceName));
    }

    public City AddCityAsync(long cityId, string name)
    {
        var result = new City(cityId, name, Id);
        _cities.Add(result);
        AddEvent(new AddCityEvent(Id, cityId, name));
        return result;
    }
}