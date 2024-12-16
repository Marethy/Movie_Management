using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class ShowTimeService(IShowTimeRepository showtimeRepository, IMapper mapper) : IShowTimeService
    {
        private readonly IShowTimeRepository _showtimeRepository = showtimeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ShowTimeDTO>> GetAllShowTimesAsync()
        {
            var showtimes = await _showtimeRepository.GetAllShowTimesAsync();
            return _mapper.Map<List<ShowTimeDTO>>(showtimes);
        }

        public async Task<ShowTimeDTO?> GetShowTimeByIdAsync(int showtimeId)
        {
            var showtime = await _showtimeRepository.GetShowTimeByIdAsync(showtimeId);
            return _mapper.Map<ShowTimeDTO>(showtime);
        }

        public async Task AddShowTimeAsync(ShowTimeDTO showtimeDto)
        {
            var showtime = _mapper.Map<ShowTime>(showtimeDto);
            await _showtimeRepository.AddShowTimeAsync(showtime);
        }

        public async Task UpdateShowTimeAsync(ShowTimeDTO showtimeDto)
        {
            var showtime = _mapper.Map<ShowTime>(showtimeDto);
            await _showtimeRepository.UpdateShowTimeAsync(showtime);
        }

        public async Task DeleteShowTimeAsync(int showtimeId)
        {
            await _showtimeRepository.DeleteShowTimeAsync(showtimeId);
        }
    }
}
