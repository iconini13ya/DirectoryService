using static DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;
public class Department
{
	public Department(
		Name name,
		Identifier identifier, 
		Department? parent,
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
	}

	#region properties
	public Guid Id { get; private set; }

	public Name Name { get; private set; }

	public Identifier Identifier { get; private set; }

	public Department? Parent { get; private set; }

	public ValueObjects.Path Path => new ValueObjects.Path(Identifier,Parent);

	public Depth Depth => new Depth(Parent);

	public bool IsActive { get; set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime UpdatedAt { get; private set; }
	#endregion
}