using DirectoryService.Entities.Department;
using DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;

public class Location
{
    private readonly List<DepartmentLocation> _departments = [];

    // EF Core
    private Location() { }

    public Location(
        Name name,
        Address address,
        DateTime updatedAt,
        ValueObjects.TimeZone timeZone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        TimeZone = timeZone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; } = null!;

    public Address Address { get; private set; } = null!;

    public ValueObjects.TimeZone TimeZone { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentLocation> Departments => _departments;
}