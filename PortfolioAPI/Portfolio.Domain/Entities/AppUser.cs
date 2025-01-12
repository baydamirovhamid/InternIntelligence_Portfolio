using Microsoft.AspNetCore.Identity;

namespace Portfolio.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
