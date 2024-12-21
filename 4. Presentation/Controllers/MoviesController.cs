using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IMovieService movieService) : BaseController
    {
        private readonly IMovieService _movieService= movieService;

        [HttpGet]
        public async Task<IActionResult> GetAllMovieAsync()
        {
            var movies= await _movieService.GetAllMoviesAsync();
            return HandleResult(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieByIdAsync(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            return HandleResult(movie); 
        }
        [HttpPost]
        public async Task<IActionResult> AddMovieAsync([FromBody] MovieDTO movieDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _movieService.AddMovieAsync(movieDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, [FromBody] MovieDTO movieDTO)
        {
            if (!IsValidId(id) || id != movieDTO.MovieId) return BadRequest("Invalid ID.");

            await _movieService.UpdateMovieAsync(movieDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest("Invalid ID.");

            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }

    }
}
