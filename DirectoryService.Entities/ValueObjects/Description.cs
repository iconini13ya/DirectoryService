namespace DirectoryService.Entities.ValueObjects;

public record Description
{
    public const int MAXLENGTH = 1000;

    public Description(string? description)
    {
        if (description?.Length > MAXLENGTH)
        {
            throw new ArgumentException($"Property description should not be bigger than {MAXLENGTH} symbols");
        }

        Value = description ?? string.Empty;
    }

    public string? Value { get; }
}