using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController(IGenreService genreService) : ControllerBase
    {
        private readonly IGenreService _genreService = genreService;

        [HttpGet]
        public async Task<IActionResult> GetGenresAsync()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreByIdAsync(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID.");

            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenreAsync([FromBody] GenreDTO genreDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _genreService.AddGenreAsync(genreDto);
            return CreatedAtAction(nameof(GetGenreByIdAsync), new { id = genreDto.GenreId }, genreDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreAsync(int id, [FromBody] GenreDTO genreDto)
        {
            if (id <= 0 || id != genreDto.GenreId) return BadRequest("Invalid ID.");

            await _genreService.UpdateGenreAsync(genreDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID.");

            await _genreService.DeleteGenreAsync(id);
            return NoContent();
        }
    }
}