namespace DirectoryService.Entities.ValueObjects;

public record Address
{
	public Address(string address)
	{
		if (string.IsNullOrWhiteSpace(address))
			throw new ArgumentException("Адрес не может быть пустым", nameof(address));

		var parts = address.Split(',', StringSplitOptions.TrimEntries);

		if (parts.Length < 3)
			throw new ArgumentException("Адрес должен содержать 3 части через запятую", nameof(address));

		City = parts[0];
		Street = parts[1];
		Building = parts[2];
	}

	public string City { get; }

	public string Street { get; }

	public string Building { get; }
}