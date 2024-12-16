using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllSeatsAsync();
        Task<Seat?> GetSeatByIdAsync(int seatId);
        Task AddSeatAsync(Seat seat);
        Task DeleteSeatAsync(int seatId);
        Task UpdateSeatAsync(Seat seat);
        Task AddSeatsAsync(List<Seat> seats);



    }
}
