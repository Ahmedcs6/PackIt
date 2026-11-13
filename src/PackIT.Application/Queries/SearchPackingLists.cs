using PackIT.Application.DTO;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Application.Queries;

public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
{
	public string SearchPhrase { get; set; } = "";
}
