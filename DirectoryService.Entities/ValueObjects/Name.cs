namespace DirectoryService.Entities.ValueObjects;

public record Name
{
    public Name(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > MaxLength || name.Length < MinLength)
        {
            throw new ArgumentException($"Property Department name should not : be empty, less than {MinLength} and bigger than {MaxLength} symbols");
        }

        Value = name;
    }

    public const int MaxLength = 150;
    public const int MinLength = 3;
    public string Value { get; }
}