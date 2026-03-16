using DirectoryService.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Repositories.Location;

public sealed class LocationsRepository : ILocationRepository
{
    private readonly DirectoryServiceDbContext _context;
    public LocationsRepository(DirectoryServiceDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Entities.Location.Location location, CancellationToken cancellationToken)
    {
        await _context.Locations.AddAsync(location, cancellationToken);

        _context.SaveChanges();
    }

    public async Task<Guid?> GetLocationByAddressAsync(Address locationAddress, CancellationToken cancellationToken)
    {
        return null;
    }

    public async Task<Guid?> GetLocationByNameAsync(Name locationName, CancellationToken cancellationToken)
    {
        return null;
    }
}
