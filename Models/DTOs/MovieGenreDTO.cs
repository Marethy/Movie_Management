using WebApplication1.Models.Entities;

namespace WebApplication1.Models.DTOs
{
    public class MovieGenreDTO
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }

        public required MovieDTO Movie { get; set; }
        public required GenreDTO Genre { get; set; }
    }
}
