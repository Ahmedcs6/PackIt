using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions;

public class PackingListNotFoundException : PackItException
{
	public PackingListNotFoundException(Guid packingListId)
		: base($"Packing list with id '{packingListId}' not found.")
	{
		PackingListId = packingListId;
	}

	public Guid PackingListId { get; }
}
