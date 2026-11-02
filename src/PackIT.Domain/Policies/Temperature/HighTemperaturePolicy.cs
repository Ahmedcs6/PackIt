using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal sealed class HighTemperaturePolicy : IPackingItemsPolycies
{
	public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
		[new("Sunglasses", 1), new("Hat", 1), new("Cream with UV filter", 1)];

	public bool IsApplicable(PolicyData data) => data.Temperature > 25D;
}
