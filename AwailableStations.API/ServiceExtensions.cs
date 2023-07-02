using Microsoft.EntityFrameworkCore;

using AwailableStations.DataAccess.PostgreSql;
using AvailableStations.Infrastucture.Interfaces;
using AvailableStations.Infrastucture.Implementation;

namespace AwailableStations.API
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddPostgresDb(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("PostgresConnection");
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(connectionString, o => o.UseNetTopologySuite());
			});

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IStationRepository, StationRepository>();

			return services;
		}
	}
}
