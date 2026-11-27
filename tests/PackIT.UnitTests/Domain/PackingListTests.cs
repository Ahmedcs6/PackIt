using PackIT.Domain.Entities;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using Shouldly;

namespace PackIT.UnitTests.Domain;

public class PackingListTests
{
	[Fact]
	public void AddItem_Throws_PackingItemAlreadyExistsException_When_there_Is_Already_Item_With_The_Same_Name()
	{
		//ARRANGE
		var packingList = GetPackingList();
		packingList.AddItem(new PackingItem("item 1", 1));

		//ACT
		var exception = Record.Exception(() => packingList.AddItem(new PackingItem("item 1", 1)));

		//ASSERT
		exception.ShouldNotBeNull();
		exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
	}

	[Fact]
	public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
	{
		var packingList = GetPackingList();

		var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

		exception.ShouldBeNull();
		packingList.Events.Count().ShouldBe(1);

		var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

		@event.ShouldNotBeNull();
		@event.PackingItem.Name.ShouldBe("Item 1");
	}

	[Fact]
	public void AddItem_Adds_Event_For_Each_Item()
	{
		var packingList = GetPackingList();

		packingList.AddItem(new PackingItem("Item 1", 1));
		packingList.AddItem(new PackingItem("Item 2", 1));

		var events = packingList.Events.OfType<PackingItemAdded>().ToList();

		events.Count.ShouldBe(2);
		events.Select(e => e.PackingItem.Name).ShouldBe(new[] { "Item 1", "Item 2" });
		packingList.Version.ShouldBe(1);
	}

	[Fact]
	public void ClearEvents_Resets_Events_And_Allows_Version_Increment_Again()
	{
		var packingList = GetPackingList();

		packingList.AddItem(new PackingItem("Item 1", 1));
		packingList.Version.ShouldBe(1);

		packingList.ClearEvents();

		packingList.Events.ShouldBeEmpty();
		packingList.Version.ShouldBe(1);

		packingList.AddItem(new PackingItem("Item 2", 1));

		packingList.Events.Count().ShouldBe(1);
		packingList.Version.ShouldBe(2);
	}

	#region ARRANGE
	private readonly IPackingListFactory _factory;

	private PackingList GetPackingList()
	{
		var packingList = _factory.Create(
			Guid.NewGuid(),
			"MyList",
			Localization.Create("Warsaw, Poland")
		);
		packingList.ClearEvents();
		return packingList;
	}

	public PackingListTests()
	{
		_factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolycies>());
	}

	#endregion
}
