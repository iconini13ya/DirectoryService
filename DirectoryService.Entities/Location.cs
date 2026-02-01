using static DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;

public class Location
{
    private readonly List<DepartmentLocation> _locationDepartments = [];

    public Location(
        Name name,
        string address,
        bool isActive,
        DateTime createdAt,
        DateTime updatedAt,
        ValueObjects.TimeZone timeZone,
        IEnumerable<DepartmentLocation> locationDepartments
        )
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        TimeZone = timeZone;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        _locationDepartments = locationDepartments.ToList();
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public string Address { get; private set; }

    public ValueObjects.TimeZone TimeZone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    IReadOnlyList<DepartmentLocation> LocationDepartments => _locationDepartments;
}