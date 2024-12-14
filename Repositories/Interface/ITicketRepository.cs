using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int ticketId);
        Task AddTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int ticketId);
        Task UpdateTicketAsync(Ticket ticket);

    }
}
