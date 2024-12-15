using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface ITicketService
    {
        Task<List<TicketDTO>> GetAllTicketsAsync();
        Task<TicketDTO?> GetTicketByIdAsync(int ticketId);
        Task AddTicketAsync(TicketDTO ticketDto);
        Task UpdateTicketAsync(TicketDTO ticketDto);
        Task DeleteTicketAsync(int ticketId);
    }
}
