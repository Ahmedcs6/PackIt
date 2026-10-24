using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListNameException : PackItException
{
	public EmptyPackingListNameException()
		: base("packing list name cannot be empty.") { }
}
