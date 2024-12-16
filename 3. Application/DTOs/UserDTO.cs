namespace WebApplication1.Application.DTOs
{
    public class UserDTO
    {
        public  string Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public  string? PhoneNumber { get; set; }

            


        public required List<string> Roles { get; set; }
    }
}
