namespace PackIT.Infrastructure.EF.Models;

internal class LocalizationReadModel
{
	public string Country { get; set; }
	public string City { get; set; }

	public static LocalizationReadModel Create(string value)
	{
		var localizationSplit = value.Split(',');
		return new() { City = localizationSplit[0], Country = localizationSplit[1] };
	}

	public override string ToString() => $"{City},{Country}";
}
