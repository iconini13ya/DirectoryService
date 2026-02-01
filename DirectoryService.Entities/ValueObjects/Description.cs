namespace DirectoryService.Entities.ValueObjects;

public record Description
{
    public Description(string description)
    {
        if (description?.Length > 1000)
        {
            throw new ArgumentException("Property description should not be bigger than 1000 symbols");
        }

        Value = description;
    }

    public string? Value { get; }
}