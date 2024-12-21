using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(ITicketService ticketService) : BaseController
    {
        private readonly ITicketService _ticketService = ticketService;
        [HttpGet]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return HandleResult(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketByIdAsync(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return HandleResult(ticket);
        }
        [HttpPost]
        public async Task<IActionResult> AddTicketAsync([FromBody] TicketDTO ticketDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.AddTicketAsync(ticketDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketAsync(int id, [FromBody] TicketDTO ticketDto)
        {
            if (!IsValidId(id) || id != ticketDto.TicketID) return BadRequest(ModelState);
            await _ticketService.UpdateTicketAsync(ticketDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest(ModelState);
            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
    }
}
