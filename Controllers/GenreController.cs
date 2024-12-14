using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreService _genreService;

        public GenresController(GenreService genreService)
        {
            _genreService = genreService;
        }

        // Lấy tất cả thể loại
        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> GetGenres()
        {
            try
            {
                var genres = await _genreService.GetAllGenresAsync();
                return Ok(genres);  // Trả về danh sách thể loại
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Lấy thể loại theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetGenreById(int id)
        {
            try
            {
                var genre = await _genreService.GetGenreByIdAsync(id);
                if (genre == null)
                {
                    return NotFound();  // Nếu không tìm thấy thể loại
                }
                return Ok(genre);  // Trả về thể loại tìm thấy
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Thêm mới thể loại
        [HttpPost]
        public async Task<ActionResult> AddGenre(GenreDTO genreDto)
        {
            try
            {
                await _genreService.AddGenreAsync(genreDto);
                return CreatedAtAction(nameof(GetGenreById), new { id = genreDto.GenreId }, genreDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Cập nhật thể loại
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGenre(int id, GenreDTO genreDto)
        {
            try
            {
                if (id != genreDto.GenreId)
                {
                    return BadRequest("The genre ID does not match the route ID.");
                }

                await _genreService.UpdateGenreAsync(genreDto);
                return NoContent();  // Trả về status code 204 nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Xóa thể loại theo ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            try
            {
                await _genreService.DeleteGenreAsync(id);
                return NoContent();  // Trả về status code 204 nếu xóa thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
