    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Data;
    using WebApplication1.Models.Entities;
    using WebApplication1.Repositories.Interface;

    namespace WebApplication1.Repositories
    {
        public class MovieGenreRepository : IMovieGenreRepository
        {
            private readonly ApplicationDbContext _context;

            public MovieGenreRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<MovieGenre>> GetAllMovieGenresAsync()
            {
                return await _context.MovieGenres.ToListAsync();
            }

            public async Task<MovieGenre?> GetMovieGenreByIdAsync(int movieId, int genreId)

            {
                return await _context.MovieGenres.FirstOrDefaultAsync(m => m.MovieID == movieId && m.GenreID == genreId);
            }

            public async Task AddMovieGenreAsync(MovieGenre movieGenre)
            {
                _context.MovieGenres.Add(movieGenre);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateMovieGenreAsync(MovieGenre movieGenre)
            {
                _context.MovieGenres.Update(movieGenre);
                await _context.SaveChangesAsync();
            }

        public async Task DeleteMovieGenreAsync(int movieId, int genreId)
        {
            var movieGenre = await GetMovieGenreByIdAsync(movieId, genreId);
            if (movieGenre != null)
            {
                _context.MovieGenres.Remove(movieGenre);
                await _context.SaveChangesAsync();
            }
        }

    }
}
