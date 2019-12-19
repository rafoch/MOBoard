using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MOBoard.Auth.Users.Read.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ChangePassword { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
        public ISet<RefreshToken> Tokens { get; set; }
    }
}