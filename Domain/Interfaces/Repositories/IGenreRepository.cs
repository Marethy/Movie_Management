using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> GetGenreByIdAsync(int genreId);
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int genreId);

    }
}
