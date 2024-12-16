using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface ITheaterRepository
    {
        Task<IEnumerable<Theater>> GetAllTheatersAsync();
        Task<Theater?> GetTheaterByIdAsync(int theaterId);
        Task AddTheaterAsync(Theater theater);
        Task DeleteTheaterAsync(int theaterId);
        Task UpdateTheaterAsync(Theater theater);

    }
}
