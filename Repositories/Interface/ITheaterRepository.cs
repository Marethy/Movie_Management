using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface ITheaterRepository
    {
        Task<IEnumerable<Theater>> GetAllTheatersAsync();
        Task<Theater> GetTheaterByIdAsync(int theaterId);
        Task AddTheaterAsync(Theater theater);
        Task DeleteTheaterAsync(int theaterId);
        Task UpdateTheaterAsync(Theater theater);

    }
}
