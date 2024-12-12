using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

public interface IMovieService
{
    Task<List<MovieDTO>> GetAllMoviesAsync();
    Task<MovieDTO> GetMovieByIdAsync(int movieId);
    Task AddMovieAsync(MovieDTO movieDto);
    Task UpdateMovieAsync(MovieDTO movieDto);
    Task DeleteMovieAsync(int movieId);
}
