using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Infrastructure.Postgres.Repositories.Location;

public interface ILocationRepository
{
    Task<Result<Guid, Error[]>> AddAsync(Entities.Location.Location location, CancellationToken cancellationToken);

    Task<UnitResult<Error[]>> GetLocationByCriteriaAsync<T>(T searchCriteria, CancellationToken cancellationToken);
}
