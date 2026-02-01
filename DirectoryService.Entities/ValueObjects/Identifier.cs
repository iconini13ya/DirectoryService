using System.Text.RegularExpressions;

namespace DirectoryService.Entities.ValueObjects;

public record Identifier
{
    public Identifier(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier) || identifier.Length > 30 || identifier.Length < 3 || !Regex.IsMatch(identifier, @"^[a-zA-Z]+$"))
        {
            throw new ArgumentException($"Property identifier should not : be empty, less than {MinLength} and bigger than {MaxLength} symbols and contains only latin alphabet");
        }

        Value = identifier;
    }

    public const int MaxLength = 30;
    public const int MinLength = 3;
    public string Value { get; }
}
