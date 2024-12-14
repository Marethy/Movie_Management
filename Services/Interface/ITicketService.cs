using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interface
{
    public interface ITicketService
    {
        Task<List<TicketDTO>> GetAllTicketsAsync();
        Task<TicketDTO> GetTicketByIdAsync(int ticketId);
        Task AddTicketAsync(TicketDTO ticketDto);
        Task UpdateTicketAsync(TicketDTO ticketDto);
        Task DeleteTicketAsync(int ticketId);
    }
}
