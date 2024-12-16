using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Domain.Entities
{
    public class User : IdentityUser
    {
        [StringLength(100)]
        public  string? FullName = string.Empty;
        public  DateTime? DateOfBirth { get; set; }

    }
}
