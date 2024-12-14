namespace WebApplication1.Models.Entities
{
    public class Room
    {
        public int RoomID { get; set; }
        public required string RoomName { get; set; }
        public required int Capacity { get; set; }
        public required int TheaterID { get; set; }
        public required Theater Theater { get; set; }

        public required ICollection<Seat> Seats { get; set; }
        public ICollection<ShowTime>? ShowTimes { get; set; }
    }
}