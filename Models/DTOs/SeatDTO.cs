using WebApplication1.Models.Entities;
using WebApplication1.Utils.Enums;

namespace WebApplication1.Models.DTOs
{
    public class SeatDTO
    {
        public int SeatID { get; set; }
        public required int RoomID { get; set; }
        public required string SeatNumber { get; set; }
        public required SeatStatus Status { get; set; }

        public required RoomDTO Room { get; set; }
    }
}
