using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Application.Services;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController(IRoomService roomService, ISeatService seatService) : BaseController
    {
        private readonly IRoomService _roomService = roomService;
        private readonly ISeatService _seatService = seatService;

        [HttpGet]   
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return HandleResult(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomByIdAsync(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            return HandleResult(room);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoomAsync([FromBody] RoomDTO roomDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _roomService.AddRoomAsync(roomDto);
            // Tự động tạo ghế cho phòng dựa trên capacity
            await _seatService.GenerateSeatsForRoomAsync(roomDto.RoomID, roomDto.Capacity);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomAsync(int id, [FromBody] RoomDTO roomDto)
        {
            if (!IsValidId(id) || id != roomDto.RoomID) return BadRequest(ModelState);
            await _roomService.UpdateRoomAsync(roomDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest(ModelState);
            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }
    }
}
