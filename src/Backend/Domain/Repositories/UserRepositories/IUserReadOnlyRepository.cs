using Domain.Entities;

namespace Domain.Repositories.UserRepositories;

public interface IUserReadOnlyRepository
{
	Task<bool> ExistsByEmail(string email);
	Task<User> GetByEmailAndPassword(string email, string password);
	Task<User> GetByEmail(string email);
	Task<User> GetById(int id);
}