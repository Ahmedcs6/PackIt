using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PackIT.Shared.Services;

internal sealed class AppInitializer : IHostedService
{
	private readonly IServiceProvider _serviceProvider;

	public AppInitializer(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		var contextTypes = AppDomain
			.CurrentDomain.GetAssemblies()
			.SelectMany(a => a.GetTypes())
			.Where(a =>
				typeof(DbContext).IsAssignableFrom(a) && !a.IsInterface && a != typeof(DbContext)
			);
		using var scope = _serviceProvider.CreateScope();
		foreach (var type in contextTypes)
		{
			if (scope.ServiceProvider.GetRequiredService(type) is not DbContext dbContext)
				continue;
			await dbContext.Database.MigrateAsync();
		}
	}

	public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
