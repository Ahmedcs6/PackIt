using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Repositories;

public interface IPackingListRepositories
{
	Task AddAsync(PackingList packingList);
	Task<PackingList> GetAsync(PackingListId id);
	Task UpdateAsync(PackingList packingList);
	Task DeleteAsync(PackingListId id);
}
