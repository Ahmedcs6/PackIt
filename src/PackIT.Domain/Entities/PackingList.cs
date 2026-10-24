using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Entities;

public class PackingList
{
	public Guid Id { get; }
	private PackingListName _name;
	private Localization _localization;

	internal PackingList(Guid id, string name, Localization localization)
	{
		Id = id;
		_name = name;
		_localization = localization;
	}
}
