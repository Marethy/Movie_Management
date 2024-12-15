using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class TicketService(ITicketRepository ticketRepository, IMapper mapper) : ITicketService
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<TicketDTO>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllTicketsAsync();
            return _mapper.Map<List<TicketDTO>>(tickets);
        }

        public async Task<TicketDTO?> GetTicketByIdAsync(int ticketId)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task AddTicketAsync(TicketDTO ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.AddTicketAsync(ticket);
        }

        public async Task UpdateTicketAsync(TicketDTO ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.UpdateTicketAsync(ticket);
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            await _ticketRepository.DeleteTicketAsync(ticketId);
        }
    }
}
