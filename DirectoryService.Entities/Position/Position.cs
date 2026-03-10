using DirectoryService.Entities.Department;
using DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities.Position;

public class Position
{
    private readonly List<DepartmentPosition> _departments = [];

    // EF Core
    private Position() { }

    public Position(
        Name name,
        Description description,
        DateTime updatedAt)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; } = null!;

    public Description Description { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentPosition> Departments => _departments;
}

