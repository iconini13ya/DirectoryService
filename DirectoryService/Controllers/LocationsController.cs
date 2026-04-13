using DirectoryService.Application.Location;
using DirectoryService.Contracts.LocationDTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.EndpointResult;

namespace DirectoryService.Controllers;

[ApiController]
[Route("api/locations")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "<Pending>")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>")]
    public async Task<EndpointResult<Guid>> Create(
        [FromServices] LocationsService locationService,
        [FromBody] CreateLocationDto dto,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(locationService);

        return await locationService.Create(dto, cancellationToken);
    }
}
