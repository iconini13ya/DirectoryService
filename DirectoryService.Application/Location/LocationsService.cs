using DirectoryService.Contracts.LocationDTOs;
using DirectoryService.Entities.ValueObjects;
using FluentValidation;
using Microsoft.Extensions.Logging;
using DirectoryService.Infrastructure.Postgres.Repositories.Location;

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

    public async Task<Guid> Create(CreateLocationDto request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var locationName = new Name(request.name);
        var locationAddress = new Address(request.address);
        var locationTimeZone = new Entities.ValueObjects.TimeZone(request.timeZone);

        if ((await _locationRepository.GetLocationByNameAsync(locationName, cancellationToken) ?? 
            await _locationRepository.GetLocationByAddressAsync(locationAddress, cancellationToken)) 
            is not null)
        {
            throw new ValidationException("Локация с таким названием или адресом уже существует в системе");
        }

        var location = new Entities.Location.Location(locationName, locationAddress, locationTimeZone);

        await _locationRepository.AddAsync(location, cancellationToken);

        _logger.LogInformation("Location created with id {LocationId}", location.Id);

        return location.Id;
    }
}
