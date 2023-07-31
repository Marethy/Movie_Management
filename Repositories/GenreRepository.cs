using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories
{
    public class GenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetGenreByIdAsync(int GenreId)

        {
            return await _context.Genres.FirstOrDefaultAsync(m => m.GenreId == GenreId);
        }

        public async Task AddGenreAsync(Genre Genre)
        {
            _context.Genres.Add(Genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGenreAsync(Genre Genre)
        {
            _context.Genres.Update(Genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int GenreId)
        {
            var Genre = await GetGenreByIdAsync(GenreId);
            if (Genre != null)
            {
                _context.Genres.Remove(Genre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
