using System.Text.Json.Serialization;

namespace DirectoryService.Entities.ValueObjects;

public record Path
{
	public string Value { get; }

	// EF Core
	[JsonConstructor]
	private Path(string value)
	{
		Value = value;
	}

	public Path(Identifier identifier, Path? parentPath)
	{
		Value = parentPath?.Value is not null ?
			$"{parentPath.Value}.{identifier.Value}" :
			identifier.Value;
	}
}
