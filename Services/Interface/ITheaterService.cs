using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interface
{
    public interface ITheaterService
    {
        Task<List<TheaterDTO>> GetAllTheatersAsync();
        Task<TheaterDTO> GetTheaterByIdAsync(int theaterId);
        Task AddTheaterAsync(TheaterDTO theaterDto);
        Task UpdateTheaterAsync(TheaterDTO theaterDto);
        Task DeleteTheaterAsync(int theaterId);
    }
}
