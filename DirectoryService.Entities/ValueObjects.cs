using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DirectoryService.Entities;

public sealed class ValueObjects
{
	public record Name
	{
		public const int MaxLength = 150;
		public const int MinLength = 3;

		public string Value {  get; }

        public Name(string name)
		{
			if (string.IsNullOrWhiteSpace(name) || name.Length > MaxLength || name.Length < MinLength)
			{
				throw new ArgumentException($"Property Department name should not : be empty, less than {MinLength} and bigger than {MaxLength} symbols");
			}

			Value = name;
		}
	}

    public record Identifier
	{
        public const int MaxLength = 30;
        public const int MinLength = 3;
        public string Value { get; }

        public Identifier(string identifier)
		{
            if (string.IsNullOrWhiteSpace(identifier) || identifier.Length > 30 || identifier.Length < 3 || !Regex.IsMatch(identifier, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException($"Property identifier should not : be empty, less than {MinLength} and bigger than {MaxLength} symbols and contains only latin alphabet");
            }

            Value = identifier;
        }
	}

    public record Path
	{
        public string Value { get; }

        public Path(Identifier identifier, Department? parent)
        {
            if (parent is not null)
            {
                Value = $"{parent.Path.Value}.{identifier.Value}";
            }
            Value = identifier.Value;
        }
    }

    public record Depth
    {
        public int Value { get; }

        public Depth(Department? parent)
        {
            if (parent is not null)
            {
                Value = parent.Depth.Value + 1;
            }
            Value = 1;
        }
    }

    public record TimeZone
    {
        public string Value { get; }

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
    }

    public record Description
    {
        public string? Value { get; }

        public Description(string description)
        {
            if (description?.Length > 1000)
            {
                throw new ArgumentException("Property description should not be bigger than 1000 symbols");
            }

            Value = description;
        }
    }

}

