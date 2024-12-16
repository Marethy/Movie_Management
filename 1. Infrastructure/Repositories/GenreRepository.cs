using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class GenreRepository(ApplicationDbContext context) : IGenreRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetGenreByIdAsync(int genreId)

        {
            return await _context.Genres.FirstOrDefaultAsync(m => m.GenreId == genreId);
        }

        public async Task AddGenreAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            var genre = await GetGenreByIdAsync(genreId);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
