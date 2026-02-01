using static DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;

public class Position
{
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

	public Name Name { get; private set; }

	public Description Description { get; private set; }

	public bool IsActive { get; private set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime UpdatedAt { get; private set; }
}

