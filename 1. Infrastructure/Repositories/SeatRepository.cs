using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class SeatRepository(ApplicationDbContext context) : ISeatRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
            return await _context.Seats.ToListAsync();

        }
        public async Task<Seat?> GetSeatByIdAsync(int seatId)
        {
            return await _context.Seats.FirstOrDefaultAsync(s => s.SeatID == seatId);
        }
        public async Task AddSeatAsync(Seat seat)
        {
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSeatAsync(int seatId)
        {
            var seat = await GetSeatByIdAsync(seatId);
            if (seat != null)
            {
                _context.Seats.Remove(seat);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateSeatAsync(Seat seat)
        {
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
        }
    }
}
