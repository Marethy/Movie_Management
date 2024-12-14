namespace WebApplication1.Models.DTOs
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public required string RoomName { get; set; }
        public required  int Capacity { get; set; }
        public required int TheaterID { get; set; }
        public  List<SeatDTO> Seats { get; set; } = new List<SeatDTO>();


    }
}
