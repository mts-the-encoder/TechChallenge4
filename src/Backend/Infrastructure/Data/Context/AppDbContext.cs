using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<User> User { get; set; }
	public DbSet<Movie> Movie { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}
