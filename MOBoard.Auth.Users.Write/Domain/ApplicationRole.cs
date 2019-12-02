using System;
using Microsoft.AspNetCore.Identity;

namespace MOBoard.Auth.Users.Write.Domain
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}