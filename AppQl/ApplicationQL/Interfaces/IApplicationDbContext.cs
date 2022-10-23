using DomainQl.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Station> Stations { get; }
        DbSet<AirQualityTest> AirQualityTests { get; }
        DbSet<City> Cities { get; }
        DbSet<Commune> Communes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}