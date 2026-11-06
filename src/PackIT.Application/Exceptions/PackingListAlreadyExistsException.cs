using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Application.Exceptions;

public class PackingListAlreadyExistsException : PackItException
{
	public PackingListAlreadyExistsException(string name)
		: base($"Packing list with name '{name}' already exists.")
	{
		Name = name;
	}

	public string Name { get; }
}
