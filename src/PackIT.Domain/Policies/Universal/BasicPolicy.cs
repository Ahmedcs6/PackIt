using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal;

public class BasicPolicy : IPackingItemsPolycies
{
	private const uint MaximumQuantityOfClothes = 7;

	public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
		[
			new("Pants", Math.Min(data.Days, MaximumQuantityOfClothes)),
			new("Socks", Math.Min(data.Days, MaximumQuantityOfClothes)),
			new("T-Shirt", Math.Min(data.Days, MaximumQuantityOfClothes)),
			new("Trousers", data.Days > 7 ? 1u : 2u),
			new("Shampoo", 1),
			new("Touthbrush", 1),
			new("TouthPaste", 1),
			new("Towel", 1),
			new("Bag pack", 1),
			new("Passport", 1),
			new("Phone Charger", 1),
		];

	public bool IsApplicable(PolicyData _) => true;
}
