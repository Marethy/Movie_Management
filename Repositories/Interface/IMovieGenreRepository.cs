using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface IMovieGenreRepository
    {
        Task<IEnumerable<MovieGenre>> GetAllMovieGenresAsync();
        Task<MovieGenre?> GetMovieGenreByIdAsync(int movieGenreId);
        Task AddMovieGenreAsync(MovieGenre movieGenre);
        Task UpdateMovieGenreAsync(MovieGenre movieGenre);
        Task DeleteMovieGenreAsync(int movieGenreId);


    }
}
