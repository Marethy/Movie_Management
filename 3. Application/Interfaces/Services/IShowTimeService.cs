using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IShowTimeService
    {
        Task<List<ShowTimeDTO>> GetAllShowTimesAsync();
        Task<ShowTimeDTO?> GetShowTimeByIdAsync(int showTimeId);
        Task AddShowTimeAsync(ShowTimeDTO showTimeDto);
        Task UpdateShowTimeAsync(ShowTimeDTO showTimeDto);
        Task DeleteShowTimeAsync(int showTimeId);
    }
}
