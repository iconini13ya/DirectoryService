namespace DirectoryService.Entities.ValueObjects;

public record Name
{
    public const int MAXLENGTH = 150;
    public const int MINLENGTH = 3;

    public Name(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > MAXLENGTH || name.Length < MINLENGTH)
        {
            throw new ArgumentException($"Property Department name should not : be empty, less than {MINLENGTH} and bigger than {MAXLENGTH} symbols");
        }

        Value = name;
    }

    public string Value { get; }
}