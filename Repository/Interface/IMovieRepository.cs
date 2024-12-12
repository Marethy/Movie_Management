using WebApplication1.Entities;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(int id);
    Task AddAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(int id);
}
