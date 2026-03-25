namespace DirectoryService.Contracts.LocationDTOs;

public record CreateLocationDto(
    string name,
    string address,
    string timeZone
    );

