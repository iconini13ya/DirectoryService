namespace DirectoryService.Entities.ValueObjects;

public record Path
{
    public Path(Identifier identifier, Path? parentPath)
    {
        Value = parentPath?.Value is not null ?
            $"{parentPath.Value}.{identifier.Value}" :
            identifier.Value;
    }

    public string Value { get; }
}
