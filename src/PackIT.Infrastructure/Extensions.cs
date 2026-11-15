using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure
{
	public static class Extesions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddQueries();
			return services;
		}
	}
}
