using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DirectoryService.Entities;

public sealed class ValueObjects
{
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

    public record TimeZone
    {
        public TimeZone(string timeZone)
        {
            try
            {
                TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                Value = timeZone;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Wrong argument {timeZone}, that trigger exception {e}");
            }
        }

        public string Value { get; }
    }

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

}
