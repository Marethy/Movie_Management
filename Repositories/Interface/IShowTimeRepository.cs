using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface IShowTimeRepository
    {
        Task<IEnumerable<ShowTime>> GetAllShowTimesAsync();
        Task<ShowTime> GetShowTimeByIdAsync(int showTimeId);
        Task AddShowTimeAsync(ShowTime showTime);
        Task DeleteShowTimeAsync(int showTimeId);
        Task UpdateShowTimeAsync(ShowTime showTime);

    }
}
