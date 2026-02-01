namespace DirectoryService.Entities.ValueObjects;

public record Depth
{
    public Depth(Depth? parentDepth)
    {
        Value = parentDepth?.Value is not null ?
            parentDepth.Value + 1 :
            1;
    }

    public int Value { get; }
}
