using CSharpFunctionalExtensions;

namespace DirectoryService.Infrastructure.Postgres.Repositories.Location;

public interface ILocationRepository
{
    Task<Result<Guid, Exception>> AddAsync(Entities.Location.Location location, CancellationToken cancellationToken);

    Task<UnitResult<Exception>> GetLocationByCriteriaAsync<T>(T searchCriteria, CancellationToken cancellationToken);
}
