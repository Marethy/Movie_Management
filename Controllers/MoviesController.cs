using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies =await _context.Movies.ToListAsync();
            return Ok();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie, [FromBody] List<string> genreNames)
        {
            if (genreNames == null || !genreNames.Any())
            {
                return BadRequest("At least one genre must be provided.");
            }

            // Thêm Movie vào cơ sở dữ liệu
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync(); // Lưu movie vào DB để có MovieId

            // Tạo hoặc lấy các Genre từ cơ sở dữ liệu
            foreach (var genreName in genreNames)
            {
                // Kiểm tra xem Genre có tồn tại chưa
                var genre = await _context.Genres
                    .FirstOrDefaultAsync(g => g.Name.Equals(genreName, StringComparison.OrdinalIgnoreCase));

                if (genre == null)
                {
                    // Nếu Genre không tồn tại, tạo mới
                    genre = new Genre
                    {
                        Name = genreName
                    };
                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync(); // Lưu genre mới vào DB
                }

                // Tạo MovieGenre để liên kết Movie và Genre
                var movieGenre = new MovieGenre
                {
                    MovieID = movie.MovieId,
                    GenreID = genre.GenreId,
                    Movie = movie,
                    Genre = genre
                };

                // Thêm MovieGenre vào DB
                _context.MovieGenres.Add(movieGenre);
            }

            // Lưu các MovieGenres vào DB
            await _context.SaveChangesAsync();

            // Trả về kết quả đã tạo
            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
