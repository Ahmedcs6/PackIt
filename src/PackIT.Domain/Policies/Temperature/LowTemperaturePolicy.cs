using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal sealed class LowTemperaturePolicy : IPackingItemsPolycies
{
	public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
		[
			new("Winter hat", 1),
			new("Scarf", 1),
			new("Gloves", 1),
			new("Hoodie", 1),
			new("Warm jacket", 1),
		];

	public bool IsApplicable(PolicyData data) => data.Temperature < 10D;
}
