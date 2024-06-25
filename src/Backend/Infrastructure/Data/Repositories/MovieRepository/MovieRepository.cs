using Domain.Entities;
using Domain.Repositories.MovieRepositories;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.MovieRepository;

public class MovieRepository : IMovieReadOnlyRepository, IMovieWriteOnlyRepository
{
	private readonly AppDbContext _context;

	public MovieRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Movie> GetById(int id)
	{
		return await _context.Movie
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task<IList<Movie>> GetAll(int userId)
	{
		return await _context.Movie
			.AsNoTracking()
			.Where(x => x.UserId == userId)
			.OrderBy(x => x.Rate)
			.ToListAsync();
	}

	public async Task<int> MoviesCount(int id)
	{
		return await _context.Movie
			.AsNoTracking()
			.Where(x => x.UserId == id)
			.CountAsync();
	}

	public async Task Add(Movie movie)
	{
		await _context.AddAsync(movie);
	}

	public async Task Delete(int id)
	{
		var movie = await _context.Movie
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);

		_context.Movie.Remove(movie);
	}

	public void Update(Movie movie)
	{
		_context.Movie.Update(movie);
	}
}