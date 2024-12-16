using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController(IShowTimeService showtimeService) : BaseController
    {
        private readonly IShowTimeService _showtimeService = showtimeService;
        [HttpGet]
        public async Task<IActionResult> GetAllShowTimesAsync()
        {
            var showtimes = await _showtimeService.GetAllShowTimesAsync();
            return HandleResult(showtimes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowTimeByIdAsync(int id)
        {
            var showtime = await _showtimeService.GetShowTimeByIdAsync(id);
            return HandleResult(showtime);
        }
        [HttpPost]
        public async Task<IActionResult> AddShowTimeAsync([FromBody] ShowTimeDTO showtimeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _showtimeService.AddShowTimeAsync(showtimeDto);
            return CreatedAtAction(nameof(GetShowTimeByIdAsync), new { id = showtimeDto.ShowTimeID }, showtimeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShowTimeAsync(int id, [FromBody] ShowTimeDTO showtimeDto)
        {
            if (!IsValidId(id) || id != showtimeDto.ShowTimeID) return BadRequest(ModelState);
            await _showtimeService.UpdateShowTimeAsync(showtimeDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowTimeAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest(ModelState);
            await _showtimeService.DeleteShowTimeAsync(id);
            return NoContent();
        }
    }
}
