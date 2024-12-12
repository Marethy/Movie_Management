using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.DTOs;
namespace WebApplication1.Models.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
     //   public List<GenreDTO> Genres { get; set; } = new List<GenreDTO>();
      //  public List<ShowTimeDTO> ShowTimes { get; set; } = new List<ShowTimeDTO>();
    }

}
