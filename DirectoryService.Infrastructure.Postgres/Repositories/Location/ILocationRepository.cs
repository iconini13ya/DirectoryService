namespace DirectoryService.Infrastructure.Postgres.Repositories.Location;

public interface ILocationRepository
{
    Task AddAsync(Entities.Location.Location location, CancellationToken cancellationToken);

    Task<Guid?> GetLocationByNameAsync(Entities.ValueObjects.Name locationName, CancellationToken cancellationToken);

    Task<Guid?> GetLocationByAddressAsync(Entities.ValueObjects.Address locationAddress, CancellationToken cancellationToken);
}
