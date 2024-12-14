using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public class ShowTimeRepository:IShowTimeRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowTimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShowTime>> GetAllShowTimesAsync()
        {
            return await _context.ShowTimes.ToListAsync();

        }
        public async Task<ShowTime?> GetShowTimeByIdAsync(int showtimeId)
        {
            return await _context.ShowTimes.FirstOrDefaultAsync(s => s.ShowTimeID == showtimeId);
        }
        public async Task AddShowTimeAsync(ShowTime showtime)
        {
            _context.ShowTimes.Add(showtime);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteShowTimeAsync(int showtimeId)
        {
            var showtime = await GetShowTimeByIdAsync(showtimeId);
            if (showtime != null)
            {
                _context.ShowTimes.Remove(showtime);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateShowTimeAsync(ShowTime showtime)
        {
            _context.ShowTimes.Update(showtime);
            await _context.SaveChangesAsync();
        }
    }
}
