namespace DirectoryService.Infrastructure.Postgres.Repositories.Location;

public interface ILocationRepository
{
    Task AddAsync(Entities.Location.Location location, CancellationToken cancellationToken);

    Task<Guid?> GetLocationByCriteriaAsync<T>(T searchCriteria, CancellationToken cancellationToken);
}
