using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Shared.Commands;

internal sealed class InMemoryCommandDispatcher(IServiceProvider serviceProvider)
	: ICommandDispatcher
{
	private readonly IServiceProvider _serviceProvider = serviceProvider;

	public async Task DispatchAsync<TCommand>(TCommand command)
		where TCommand : class, ICommand
	{
		using var scope = _serviceProvider.CreateScope();
		var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
		await handler.HandleAsync(command);
	}
}
