using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController(ITheaterService _theaterService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTheatersAsync()
        {
            var theaters = await _theaterService.GetAllTheatersAsync();
            return HandleResult(theaters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTheaterByIdAsync(int id)
        {
            var theater = await _theaterService.GetTheaterByIdAsync(id);
            return HandleResult(theater);
        }
        [HttpPost]
        public async Task<IActionResult> AddTheaterAsync([FromBody] TheaterDTO theaterDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _theaterService.AddTheaterAsync(theaterDto);
            return CreatedAtAction(nameof(GetTheaterByIdAsync), new { id = theaterDto.TheaterID }, theaterDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheaterAsync(int id, [FromBody] TheaterDTO theaterDto)
        {
            if (!IsValidId(id) || id != theaterDto.TheaterID) return BadRequest(ModelState);
            await _theaterService.UpdateTheaterAsync(theaterDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheaterAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest(ModelState);
            await _theaterService.DeleteTheaterAsync(id);
            return NoContent();
        }
    }
}
