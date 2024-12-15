using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface IMovieGenreRepository
    {
        Task<IEnumerable<MovieGenre>> GetAllMovieGenresAsync();
        Task<MovieGenre?> GetMovieGenreByIdAsync(int movieId, int genreId);
        Task AddMovieGenreAsync(MovieGenre movieGenre);
        Task UpdateMovieGenreAsync(MovieGenre movieGenre);
        Task DeleteMovieGenreAsync(int movieId, int genreId);


    }
}
