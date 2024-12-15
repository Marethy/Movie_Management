using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetAllMoviesAsync();
        Task<MovieDTO?> GetMovieByIdAsync(int movieId);
        Task AddMovieAsync(MovieDTO movieDTO);
        Task DeleteMovieAsync(int movieId);
        Task UpdateMovieAsync(MovieDTO movieDTO);


    }
}
