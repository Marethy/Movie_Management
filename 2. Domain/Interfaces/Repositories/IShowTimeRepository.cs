using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface IShowTimeRepository
    {
        Task<IEnumerable<ShowTime>> GetAllShowTimesAsync();
        Task<ShowTime?> GetShowTimeByIdAsync(int showTimeId);
        Task AddShowTimeAsync(ShowTime showTime);
        Task DeleteShowTimeAsync(int showTimeId);
        Task UpdateShowTimeAsync(ShowTime showTime);

    }
}
