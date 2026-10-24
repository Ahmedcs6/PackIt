namespace PackIT.Domain.ValueObjects;

public record Localization(string City, string Country)
{
	public static Localization Create(string value)
	{
		var localizationSplit = value.Split(',');
		return new(localizationSplit[0], localizationSplit[1]);
	}

	public override string ToString() => $"{City},{Country}";
}
