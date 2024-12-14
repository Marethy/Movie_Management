using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interface
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> GetGenreByIdAsync(int genreId);
        Task AddGenreAsync(GenreDTO genreDto);
        Task UpdateGenreAsync(GenreDTO genreDto);
        Task DeleteGenreAsync(int genreId);
    }
}
