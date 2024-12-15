using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket?> GetTicketByIdAsync(int ticketId);
        Task AddTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int ticketId);
        Task UpdateTicketAsync(Ticket ticket);

    }
}
