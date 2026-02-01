using DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;

public class Department
{
    private readonly List<Department> _childDepartments = [];

    private readonly List<DepartmentLocation> _locations = [];

    private readonly List<DepartmentPosition> _positions = [];

    public Department(
        Name name,
        Identifier identifier,
        Guid? parentId,
        DateTime updatedAt,
        Depth depth,
        ValueObjects.Path path)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        IsActive = true;
        Depth = depth;
        Path = path;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Identifier Identifier { get; private set; }

    public Guid? ParentId { get; private set; }

    public ValueObjects.Path Path { get; private set; }

    public Depth Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    IReadOnlyList<Department> Child => _childDepartments;

    IReadOnlyList<DepartmentLocation> Locations => _locations;

    IReadOnlyList<DepartmentPosition> Positions => _positions;
}