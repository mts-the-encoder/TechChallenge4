using Domain.Entities;

namespace Domain.Repositories.MovieRepositories;

public interface IMovieReadOnlyRepository
{
	Task<Movie> GetById(int id);
	Task<IList<Movie>> GetAll(int userId);
	Task<int> MoviesCount(int id);
}