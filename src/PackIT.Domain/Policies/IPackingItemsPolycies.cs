using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies;

public interface IPackingItemsPolycies
{
	bool IsApplicable(PolicyData data);
	IEnumerable<PackingItem> GenerateItems(PolicyData data);
}
