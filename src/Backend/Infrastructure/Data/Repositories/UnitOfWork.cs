using Domain.Repositories;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repositories;

public class UnitOfWork(AppDbContext context) : IDisposable, IUnitOfWork
{
	private bool _disposed;

	public void Dispose()
	{
		Dispose(true);
	}

	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing) context.Dispose();

		_disposed = true;
	}

	public async Task Commit()
	{
		await context.SaveChangesAsync();
	}
}