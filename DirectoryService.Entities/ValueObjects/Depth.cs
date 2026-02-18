using System.Text.Json.Serialization;

namespace DirectoryService.Entities.ValueObjects;

public record Depth
{
	public int Value { get; }

	// EF Core
	[JsonConstructor]
	private Depth(int value)
	{
		Value = value;
	}

	public Depth(Depth? parentDepth)
	{
		Value = parentDepth?.Value is not null ?
			parentDepth.Value + 1 :
			1;
	}
}
