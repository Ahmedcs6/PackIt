using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers;

public class RemovePackingListHandler : ICommandHandler<RemovePackingList>
{
	private readonly IPackingListRepository _repository;

	public RemovePackingListHandler(IPackingListRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(RemovePackingList command)
	{
		var packingList =
			await _repository.GetAsync(command.PackingListId)
			?? throw new PackingListNotFoundException(command.PackingListId);
		await _repository.DeleteAsync(packingList);
	}
}
