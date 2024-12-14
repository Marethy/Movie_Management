using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllSeatsAsync();
        Task<Seat?> GetSeatByIdAsync(int seatId);
        Task AddSeatAsync (Seat seat);
        Task DeleteSeatAsync(int seatId);
        Task UpdateSeatAsync(Seat seat);    

    }
}
