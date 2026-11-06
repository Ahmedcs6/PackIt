using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Repositories;

public interface IPackingListRepository
{
	Task AddAsync(PackingList packingList);
	Task<PackingList> GetAsync(PackingListId id);
	Task UpdateAsync(PackingList packingList);
	Task DeleteAsync(PackingList packingList);
}
