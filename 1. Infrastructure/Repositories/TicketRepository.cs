using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class TicketRepository(ApplicationDbContext context) : ITicketRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();

        }
        public async Task<Ticket?> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.TicketID == ticketId);
        }
        public async Task AddTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTicketAsync(int ticketId)
        {
            var ticket = await GetTicketByIdAsync(ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
