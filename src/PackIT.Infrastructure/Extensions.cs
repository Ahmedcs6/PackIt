using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Infrastructure.EF;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure
{
	public static class Extesions
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			services.AddPostgres(configuration);
			services.AddQueries();
			return services;
		}
	}
}
