using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IMovieGenreService
    {
        Task<List<MovieGenreDTO>> GetAllMovieGenresAsync();
        Task<MovieGenreDTO?> GetMovieGenreByIdAsync(int movieId, int genreId);
        Task AddMovieGenreAsync(MovieGenreDTO movieGenreDto);
        Task UpdateMovieGenreAsync(MovieGenreDTO movieGenreDto);
        Task DeleteMovieGenreAsync(int movieId, int genreId);
    }
}
