using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaffDesk.Infrastructure.Contracts;

namespace StaffDesk.Infrastructure.Database
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
			
			return services;
		}
	}
}
