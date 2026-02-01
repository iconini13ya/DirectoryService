using System.Text.RegularExpressions;

namespace DirectoryService.Entities.ValueObjects;

public record Identifier
{
    public const int MAXLENGTH = 30;
    public const int MINLENGTH = 3;

    public Identifier(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier) || identifier.Length > MAXLENGTH || identifier.Length < MINLENGTH || !Regex.IsMatch(identifier, @"^[a-zA-Z]+$"))
        {
            throw new ArgumentException($"Property identifier should not : be empty, less than {MINLENGTH} and bigger than {MAXLENGTH} symbols and contains only latin alphabet");
        }

        Value = identifier;
    }

    public string Value { get; }
}
