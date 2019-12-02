using System;
using Microsoft.AspNetCore.Identity;

namespace MOBoard.Auth.Users.Read.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ChangePassword { get; set; }
    }
}