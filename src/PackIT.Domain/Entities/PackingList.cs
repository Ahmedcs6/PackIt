using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Domain;

namespace PackIT.Domain.Entities;

public class PackingList : AggregateRoot<Guid>
{
	public Guid Id { get; }
	private PackingListName _name;
	private Localization _localization;
	private readonly LinkedList<PackingItem> _items = new();

	internal PackingList(
		Guid id,
		string name,
		Localization localization,
		LinkedList<PackingItem> items
	)
	{
		Id = id;
		_name = name;
		_localization = localization;
		_items = items;
	}

	public void AddItem(PackingItem item)
	{
		var alreadyExists = _items.Any(i => i.Name == item.Name);
		if (alreadyExists)
		{
			throw new PackingItemAlreadyExistsException(_name, item.Name);
		}

		_items.AddLast(item);
	}
}
