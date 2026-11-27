using Microsoft.Extensions.Logging;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Infrastructure.Logging;

internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
	where TCommand : class, ICommand
{
	private readonly ICommandHandler<TCommand> _commandHandler;
	private readonly ILogger<ICommandHandler<TCommand>> _logger;

	public LoggingCommandHandlerDecorator(
		ILogger<ICommandHandler<TCommand>> logger,
		ICommandHandler<TCommand> commandHandler
	)
	{
		_logger = logger;
		_commandHandler = commandHandler;
	}

	public async Task HandleAsync(TCommand command)
	{
		var commandType = command.GetType().Name;
		try
		{
			_logger.LogInformation($"started proccessing {commandType} command.");
			await _commandHandler.HandleAsync(command);
			_logger.LogInformation($"finished proccessing {commandType} command.");
		}
		catch
		{
			_logger.LogError($"Failed to proccess {commandType} command.");
			throw;
		}
	}
}
