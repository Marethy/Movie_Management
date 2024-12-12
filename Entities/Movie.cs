using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }

        [StringLength(500)]
        public required string Title { get; set; } = string.Empty;

        public required TimeSpan Duration { get; set; }

        public required DateTime ReleaseDate { get; set; }


        public required string Description { get; set; }

        [StringLength(50)]
        public required string Director { get; set; }

        public required string Actors { get; set; }

        [StringLength(50)]

        public required string Country { get; set; }

        [StringLength(500)]
        public required string Image { get; set; }

        public required ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<ShowTime>? ShowTimes { get; set; } = new List<ShowTime>();   
    }
}
