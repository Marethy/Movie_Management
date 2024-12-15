using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO?> GetGenreByIdAsync(int genreId);
        Task AddGenreAsync(GenreDTO genreDto);
        Task UpdateGenreAsync(GenreDTO genreDto);
        Task DeleteGenreAsync(int genreId);
    }
}
