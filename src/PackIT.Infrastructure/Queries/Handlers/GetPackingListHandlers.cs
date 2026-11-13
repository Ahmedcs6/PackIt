using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Infrastructure.Queries.Handlers;

public class GetPackingListHandlers : IQueryHandler<GetPackingList, PackingListDto>
{
	public async Task<PackingListDto> HandleAsync(GetPackingList query)
	{
		return null;
	}
}
