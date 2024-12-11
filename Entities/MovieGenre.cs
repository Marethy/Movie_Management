using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class MovieGenre
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }

        public required Movie Movie { get; set; }
        public required  Genre Genre { get; set; }
    }
}