using Microsoft.AspNetCore.Identity;

namespace MOBoard.Auth.Users.Write.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ChangePassword { get; set; }
    }
}