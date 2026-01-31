using static DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;
public class Department
{
	private readonly List<Department> _child = [];
	private readonly List<DepartmentLocation> _departmentLocations = [];
	private readonly List<DepartmentPosition> _departmentPositions = [];

	public Department(
		Name name,
		Identifier identifier, 
		Department? parent,
		IEnumerable<Department> child,
		IEnumerable<DepartmentLocation> departmentLocations,
		IEnumerable<DepartmentPosition> departmentPositions,
		DateTime createdAt,
		DateTime updatedAt
		)
	{
		Id = Guid.NewGuid();
		Name = name;
		Identifier = identifier;
		Parent = parent;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		IsActive = true;
		_child = child.ToList();
		_departmentLocations = departmentLocations.ToList();
		_departmentPositions = departmentPositions.ToList();
	}

	public Guid Id { get; private set; }

	public Name Name { get; private set; }

	public Identifier Identifier { get; private set; }

	public Department? Parent { get; private set; }

	public ValueObjects.Path Path => new ValueObjects.Path(Identifier,Parent);

	public Depth Depth => new Depth(Parent);

	public bool IsActive { get; set; }

	IReadOnlyList<Department> Child => _child;

	IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;

	IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;

	public DateTime CreatedAt { get; private set; }

	public DateTime UpdatedAt { get; private set; }
}