using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
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
