namespace WebApplication1.Application.DTOs
{
    public class TheaterDTO
    {
        public int TheaterID { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public List<RoomDTO> Rooms { get; set; } = new List<RoomDTO>();
    }
}
