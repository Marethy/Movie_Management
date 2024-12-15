namespace WebApplication1.Application.DTOs
{
    public class UserDTO
    {
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }




        public required List<string> Roles { get; set; }
    }
}
