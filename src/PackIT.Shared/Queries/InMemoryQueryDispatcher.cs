using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Shared.Queries;

public class InMemoryQueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
	private readonly IServiceProvider _serviceProvider = serviceProvider;

	public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
	{
		using var scope = _serviceProvider.CreateScope();
		var handlertype = typeof(IQueryHandler<,>).MakeGenericType(
			query.GetType(),
			typeof(TResult)
		);
		var handler = scope.ServiceProvider.GetRequiredService(handlertype);
		return await (Task<TResult>)
			handlertype
				.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
				?.Invoke(handler, [query]);
	}
}
