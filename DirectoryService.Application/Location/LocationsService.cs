using CSharpFunctionalExtensions;
using DirectoryService.Application.Extensions;
using DirectoryService.Contracts.LocationDTOs;
using DirectoryService.Entities.ValueObjects;
using DirectoryService.Infrastructure.Postgres.Repositories.Location;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

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

    public async Task<Result<Guid, Error[]>> Create(CreateLocationDto request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrors();
        }

        var locationName = new Name(request.name);
        var locationAddress = new Address(request.address);
        var locationTimeZone = new Entities.ValueObjects.TimeZone(request.timeZone);

        var locationByName = await _locationRepository.GetLocationByCriteriaAsync(locationName, cancellationToken);
        var locationByAddress = await _locationRepository.GetLocationByCriteriaAsync(locationAddress, cancellationToken);

        if (locationByName.IsFailure || locationByAddress.IsFailure)
        {
            return locationByName.IsFailure ?
                Result.Failure<Guid, Error[]>(locationByName.Error) :
                Result.Failure<Guid, Error[]>(locationByAddress.Error);
        }

        var location = new Entities.Location.Location(locationName, locationAddress, locationTimeZone);

        var result = await _locationRepository.AddAsync(location, cancellationToken);

        _logger.LogInformation("Location created with id {LocationId}", location.Id);

        return result;
    }
}
