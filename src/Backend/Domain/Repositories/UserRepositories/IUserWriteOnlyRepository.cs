using Domain.Entities;

namespace Domain.Repositories.UserRepositories;

public interface IUserWriteOnlyRepository
{
	Task Add(User user);
	void Update(User user);
}