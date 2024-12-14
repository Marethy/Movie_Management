using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interface
{
    public interface IShowTimeService
    {
        Task<List<ShowTimeDTO>> GetAllShowTimesAsync();
        Task<ShowTimeDTO> GetShowTimeByIdAsync(int showTimeId);
        Task AddShowTimeAsync(ShowTimeDTO showTimeDto);
        Task UpdateShowTimeAsync(ShowTimeDTO showTimeDto);
        Task DeleteShowTimeAsync(int showTimeId);
    }
}
