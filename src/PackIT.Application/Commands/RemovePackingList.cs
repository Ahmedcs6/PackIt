using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands;

public record RemovePackingList(Guid PackingListId) : ICommand;
