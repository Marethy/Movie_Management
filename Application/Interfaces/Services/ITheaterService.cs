using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface ITheaterService
    {
        Task<List<TheaterDTO>> GetAllTheatersAsync();
        Task<TheaterDTO?> GetTheaterByIdAsync(int theaterId);
        Task AddTheaterAsync(TheaterDTO theaterDto);
        Task UpdateTheaterAsync(TheaterDTO theaterDto);
        Task DeleteTheaterAsync(int theaterId);
    }
}
