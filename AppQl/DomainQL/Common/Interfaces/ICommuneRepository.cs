using DomainQl.Entities;

namespace DomainQl.Common.Interfaces;

public interface ICommuneRepository : IRepository<Commune>
{
    Task<Station?> GetStationByIdentifierAsync(long identifier, CancellationToken cancellationToken);
    Task<List<Station>> GetListAsync(CancellationToken cancellationToken);
    Task AddStationAsync(Station station);
}