using Domain.Entities;

namespace Domain.Repositories.MovieRepositories;

public interface IMovieWriteOnlyRepository
{
	Task Add(Movie movie);
	Task Delete(int id);
	void Update(Movie movie);
}