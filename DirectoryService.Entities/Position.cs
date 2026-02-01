using static DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;

public class Position
{

    public Position(
        Name name,
        Description description,
        bool isActive,
        DateTime updatedAt
        )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}

