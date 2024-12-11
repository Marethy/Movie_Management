using WebApplication1.Enums;

namespace WebApplication1.Entities
{
    public class Seat
    {
        public int SeatID { get; set; }
        public required  int RoomID { get; set; }
        public required string  SeatNumber { get; set; }
        public required SeatStatus Status { get; set; }

        public required Room Room { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}