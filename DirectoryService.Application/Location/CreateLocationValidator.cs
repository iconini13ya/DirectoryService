using DirectoryService.Contracts.LocationDTOs;
using DirectoryService.Entities.ValueObjects;
using FluentValidation;

namespace DirectoryService.Contracts.Location;

public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
	public CreateLocationValidator()
	{
		RuleFor(l => l.name)
			.NotNull()
			.NotEmpty().WithMessage("Имя не может быть пустым")
			.MaximumLength(Name.MAXLENGTH).WithMessage($"Имя не может быть длиннее {Name.MAXLENGTH}")
			.MinimumLength(Name.MINLENGTH).WithMessage($"Имя не может быть короче {Name.MINLENGTH}");

		RuleFor(l => l.address)
			.NotNull()
			.NotEmpty().WithMessage("Адрес не может быть пустым")
			.Must(BeValidAddressFormat).WithMessage("Адрес должен содержать 3 части через запятую. Город, Улица, номер дома.");

		RuleFor(l => l.timeZone)
			.NotNull()
			.NotEmpty().WithMessage("Часовой пояс не может быть пустым")
			.Must(BeValidTimeZone).WithMessage("Невалидный формат TimeZone. TimeZone должен быть в формате \"Russian Standard Time\"");
	}

	private bool BeValidAddressFormat(string address)
	{
		if (string.IsNullOrWhiteSpace(address))
			return false;

		var parts = address.Split(',', StringSplitOptions.TrimEntries);

		return parts.Length >= 3;
	}

    private bool BeValidTimeZone(string timeZone)
    {
        if (string.IsNullOrWhiteSpace(timeZone))
            return false;

        try
        {
            TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
