using static DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;

public class Location
{
    public Location(
        Name name,
        Address address,
        bool isActive,
        DateTime updatedAt,
        ValueObjects.TimeZone timeZone
        )
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        TimeZone = timeZone;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Address Address { get; private set; }

    public ValueObjects.TimeZone TimeZone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}