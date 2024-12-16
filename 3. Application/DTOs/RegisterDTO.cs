namespace WebApplication1._3._Application.DTOs
{
    public class RegisterDTO
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
        public required string Password { get; set; }
        public required  string PhoneNumber { get; set; }
    }
}
