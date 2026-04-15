using DirectoryService.Application.Location;
using DirectoryService.Contracts.LocationDTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.EndpointResult;

namespace DirectoryService.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<EndpointResult<Guid>> Create(
        [FromServices] LocationsService locationService,
        [FromBody] CreateLocationDto dto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(locationService);

        return await locationService.Create(dto, cancellationToken);
    }
}
