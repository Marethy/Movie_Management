using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class TheaterRepository(ApplicationDbContext context) : ITheaterRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Theater>> GetAllTheatersAsync()
        {
            return await _context.Theaters.ToListAsync();

        }
        public async Task<Theater?> GetTheaterByIdAsync(int theaterId)
        {
            return await _context.Theaters.FirstOrDefaultAsync(t => t.TheaterID == theaterId);
        }
        public async Task AddTheaterAsync(Theater theater)
        {
            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTheaterAsync(int theaterId)
        {
            var theater = await GetTheaterByIdAsync(theaterId);
            if (theater != null)
            {
                _context.Theaters.Remove(theater);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateTheaterAsync(Theater theater)
        {
            _context.Theaters.Update(theater);
            await _context.SaveChangesAsync();
        }
    }
}
