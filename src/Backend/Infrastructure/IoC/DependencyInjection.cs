using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration
					.GetConnectionString("DefaultConnection"),
				b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

		AddUnitOfWork(services);

		return services;
	}

	private static void AddUnitOfWork(IServiceCollection services)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}