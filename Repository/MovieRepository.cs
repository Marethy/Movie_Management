using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using WebApplication1.Entities;

namespace WebApplication1.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .FirstOrDefaultAsync(m => m.MovieId == id);
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
