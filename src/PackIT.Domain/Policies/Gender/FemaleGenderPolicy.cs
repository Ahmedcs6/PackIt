using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal sealed class FemaleGenderPolicy : IPackingItemsPolycies
{
	public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
		[new("Lipstick", 1), new("Powder", 10), new("Eyeliner", 1)];

	public bool IsApplicable(PolicyData data) => data.Gender is Consts.Gender.Female;
}
