using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController(ISeatService seatService) : BaseController
    {
        private readonly ISeatService _seatService = seatService;
        [HttpGet]
        public async Task<IActionResult> GetAllSeatsAsync()
        {
            var seats = await _seatService.GetAllSeatsAsync();
            return HandleResult(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatByIdAsync(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);
            return HandleResult(seat);
        }
        [HttpPost]
        public async Task<IActionResult> AddSeatAsync([FromBody] SeatDTO seatDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _seatService.AddSeatAsync(seatDto);
            return CreatedAtAction(nameof(GetSeatByIdAsync), new { id = seatDto.SeatID }, seatDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeatAsync(int id, [FromBody] SeatDTO seatDto)
        {
            if (!IsValidId(id) || id != seatDto.SeatID) return BadRequest(ModelState);
            await _seatService.UpdateSeatAsync(seatDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest(ModelState);
            await _seatService.DeleteSeatAsync(id);
            return NoContent();
        }
    }
}
