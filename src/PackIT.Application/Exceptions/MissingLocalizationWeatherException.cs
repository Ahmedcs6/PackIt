using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions;

public class MissingLocalizationWeatherException : PackItException
{
	public MissingLocalizationWeatherException(Localization localization)
		: base(
			$"cannot fetch weather for localization '{localization.Country}/{localization.City}'."
		)
	{
		Localization = localization;
	}

	public Localization Localization { get; }
}
