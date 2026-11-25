using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Shared.Queries;

public static class Extensions
{
	public static IServiceCollection AddQueries(this IServiceCollection services)
	{
		services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
		var assembly = Assembly.GetCallingAssembly();
		// services.Scan(s =>
		// 	s.FromAssemblies(assembly)
		// 		.AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
		// 		.AsImplementedInterfaces()
		// 		.WithScopedLifetime()
		// );

		var handlers = assembly
			.GetTypes()
			.Where(t =>
				t.IsClass
				&& !t.IsAbstract
				&& t.GetInterfaces()
					.Any(i =>
						i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)
					)
			);

		foreach (var handler in handlers)
		{
			var interfaces = handler
				.GetInterfaces()
				.Where(i =>
					i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)
				);

			foreach (var service in interfaces)
			{
				services.AddScoped(service, handler);
			}
		}
		return services;
	}
}
