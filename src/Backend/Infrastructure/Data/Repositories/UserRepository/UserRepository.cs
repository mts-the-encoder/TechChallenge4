using Domain.Entities;
using Domain.Repositories.UserRepositories;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.UserRepository;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
	private readonly AppDbContext _context;

	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<bool> ExistsByEmail(string email)
	{
		return await _context.User
			.AsNoTracking()
			.AnyAsync(x => x.Email.Equals(email));
	}

	public async Task<User> GetByEmailAndPassword(string email, string password)
	{
		return await _context.User
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));
	}

	public async Task<User> GetByEmail(string email)
	{
		return await _context.User
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Email.Equals(email));
	}

	public async Task<User> GetById(int id)
	{
		return await _context.User
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id == id);
	}

	public async Task Add(User user)
	{
		await _context.User.AddAsync(user);
	}

	public void Update(User user)
	{
		_context.User.Update(user);
	}
}