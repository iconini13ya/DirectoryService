using static DirectoryService.Entities.ValueObjects;

namespace DirectoryService.Entities;

public class Location
{
	public Location(
		Name name, 
		string address,
        ValueObjects.TimeZone timeZone,
		bool isActive,
		DateTime createdAt,
		DateTime updatedAt
		)
	{ 
		Id = Guid.NewGuid();
		Name = name;
		Address = address;
		TimeZone = timeZone;
		IsActive = true;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
	}

	public Guid Id {  get; private set; }

	public Name Name { get; private set; }

	public string Address {get; private set;}

	public ValueObjects.TimeZone TimeZone { get; private set; }

	public bool IsActive { get; set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime UpdatedAt { get; private set; }
}