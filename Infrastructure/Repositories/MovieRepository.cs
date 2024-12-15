using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;
using WebApplication1.Infrastructure.Data;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Infrastructure.Repositories
{
    public class MovieRepository(ApplicationDbContext context) : IMovieRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int movieId)

        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int movieId)
        {
            var movie = await GetMovieByIdAsync(movieId);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
