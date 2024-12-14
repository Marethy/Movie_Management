using AutoMapper;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories.Interface;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class ShowTimeService:IShowTimeService
    {
        private readonly IShowTimeRepository _showtimeRepository;
        private readonly IMapper _mapper;

        public ShowTimeService(IShowTimeRepository showtimeRepository, IMapper mapper)
        {
            _showtimeRepository = showtimeRepository;
            _mapper = mapper;
        }

        public async Task<List<ShowTimeDTO>> GetAllShowTimesAsync()
        {
            var showtimes = await _showtimeRepository.GetAllShowTimesAsync();
            return _mapper.Map<List<ShowTimeDTO>>(showtimes);
        }

        public async Task<ShowTimeDTO> GetShowTimeByIdAsync(int showtimeId)
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
