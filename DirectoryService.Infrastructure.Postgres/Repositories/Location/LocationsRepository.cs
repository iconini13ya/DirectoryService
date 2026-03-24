using CSharpFunctionalExtensions;
using DirectoryService.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DirectoryService.Infrastructure.Postgres.Repositories.Location;

public sealed class LocationsRepository : ILocationRepository
{
    private readonly DirectoryServiceDbContext _context;
    public LocationsRepository(DirectoryServiceDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid, Exception>> AddAsync(Entities.Location.Location location, CancellationToken cancellationToken)
    {
        await _context.Locations.AddAsync(location, cancellationToken);
        try
        {
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Result.Failure<Guid, Exception>(new(ex.Message));
        }
        return Result.Success<Guid, Exception>(location.Id);
    }

    public async Task<UnitResult<Exception>> GetLocationByCriteriaAsync<T>(T searchCriteria, CancellationToken cancellationToken)
    {
        //Expression<Func<Entities.Location.Location, bool>> predicate = searchCriteria switch
        //{
        //    Address address => x => x.Address == address,
        //    Name name => x => x.Name == name,
        //    _ => throw new ArgumentException($"Unsupported search criteria type: {typeof(T).Name}")
        //};

        //return await _context.Locations
        //    .Where(predicate)
        //    .Select(x => x.Id)
        //    .FirstOrDefaultAsync(cancellationToken);

        return UnitResult.Failure<Exception>(new("Somthing Went WSSrong"));
    }
}
