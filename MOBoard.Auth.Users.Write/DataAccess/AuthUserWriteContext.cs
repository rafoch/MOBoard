using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOBoard.Auth.Users.Write.Domain;

namespace MOBoard.Auth.Users.Write.DataAccess
{
    public class AuthUserWriteContext : IdentityDbContext<ApplicationUser>
    {
        public AuthUserWriteContext(DbContextOptions<AuthUserWriteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Auth");
            base.OnModelCreating(builder);
        }
    }
}