using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interface
{
    public interface ISeatService
    {
        Task<List<SeatDTO>> GetAllSeatsAsync();
        Task<SeatDTO> GetSeatByIdAsync(int seatId);
        Task AddSeatAsync(SeatDTO seatDto);
        Task UpdateSeatAsync(SeatDTO seatDto);
        Task DeleteSeatAsync(int seatId);
    }
}
