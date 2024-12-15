using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface ISeatService
    {
        Task<List<SeatDTO>> GetAllSeatsAsync();
        Task<SeatDTO?> GetSeatByIdAsync(int seatId);
        Task AddSeatAsync(SeatDTO seatDto);
        Task UpdateSeatAsync(SeatDTO seatDto);
        Task DeleteSeatAsync(int seatId);
    }
}
