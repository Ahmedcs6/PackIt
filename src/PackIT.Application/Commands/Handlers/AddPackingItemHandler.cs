using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands.Handlers
{
	public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
	{
		private readonly IPackingListRepository _repository;

		public AddPackingItemHandler(IPackingListRepository repository)
		{
			_repository = repository;
		}

		public async Task HandleAsync(AddPackingItem command)
		{
			var packingList =
				await _repository.GetAsync(command.PackingListId)
				?? throw new PackingListNotFoundException(command.PackingListId);
		}
	}
}
