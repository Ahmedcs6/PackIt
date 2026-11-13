using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Infrastructure.Queries.Handlers;

public class SearchPackingListHandler
	: IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
{
	public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
	{
		return null;
	}
}
