using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Exceptions;

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
