using DirectoryService.Contracts.LocationDTOs;
using DirectoryService.Entities.ValueObjects;
using FluentValidation;
using Microsoft.Extensions.Logging;
using DirectoryService.Infrastructure.Postgres.Repositories.Location;
using CSharpFunctionalExtensions;

namespace DirectoryService.Application.Location;

public sealed class LocationsService
{

    private readonly ILocationRepository _locationRepository;
    private readonly ILogger<LocationsService> _logger;
    private readonly IValidator<CreateLocationDto> _validator;

    public LocationsService(
        ILocationRepository locationRepository,
        ILogger<LocationsService> logger,
        IValidator<CreateLocationDto> validator
    )
    {
        _locationRepository = locationRepository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Result<Guid,Exception>> Create(CreateLocationDto request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Failure<Guid, Exception>(new(validationResult.ToString()));
        }

        var locationName = new Name(request.name);
        var locationAddress = new Address(request.address);
        var locationTimeZone = new Entities.ValueObjects.TimeZone(request.timeZone);

        var locationByName = await _locationRepository.GetLocationByCriteriaAsync(locationName, cancellationToken);
        var locationByAddress = await _locationRepository.GetLocationByCriteriaAsync(locationAddress, cancellationToken);

        if (locationByName.IsFailure || locationByAddress.IsFailure)
        {
            return Result.Failure<Guid, Exception>(new("Локация с таким названием или адресом уже существует в системе"));
        }

        var location = new Entities.Location.Location(locationName, locationAddress, locationTimeZone);

        var resutl = await _locationRepository.AddAsync(location, cancellationToken);

        _logger.LogInformation("Location created with id {LocationId}", location.Id);

        return resutl;
    }
}
