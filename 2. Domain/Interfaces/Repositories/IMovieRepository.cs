using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int movieId);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int movieId);
    }
}
