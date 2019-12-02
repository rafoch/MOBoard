using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOBoard.Auth.Users.Read.Domain;

namespace MOBoard.Auth.Users.Read.DataAccess
{
    public class AuthUserReadonlyContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AuthUserReadonlyContext(DbContextOptions<AuthUserReadonlyContext> context)
            :base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}