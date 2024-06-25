using Domain.Repositories;
using Domain.Repositories.MovieRepositories;
using Domain.Repositories.UserRepositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.MovieRepository;
using Infrastructure.Data.Repositories.UserRepository;
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
		AddRepositories(services);

		return services;
	}

	private static void AddUnitOfWork(IServiceCollection services)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();
	}

	private static void AddRepositories(IServiceCollection services)
	{
		//User
		services.AddScoped<IUserReadOnlyRepository, UserRepository>();
		services.AddScoped<IUserWriteOnlyRepository, UserRepository>();

		//Movie
		services.AddScoped<IMovieReadOnlyRepository, MovieRepository>();
		services.AddScoped<IMovieWriteOnlyRepository, MovieRepository>();
	}
}