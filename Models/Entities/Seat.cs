using WebApplication1.Utils.Enums;

namespace WebApplication1.Models.Entities
{
    public class Seat
    {
        public int SeatID { get; set; }
        public required int RoomID { get; set; }
        public required string SeatNumber { get; set; }
        public required SeatStatus Status { get; set; }

        public required Room Room { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}