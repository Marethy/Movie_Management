namespace WebApplication1.Models.Entities
{
    public class Theater
    {
        public int TheaterID {  get; set; }    
        public required string Name { get; set; }   
        public required string Address { get; set; }
        public ICollection<Room>? Rooms { get; set; } = new List<Room>();

    }
}
