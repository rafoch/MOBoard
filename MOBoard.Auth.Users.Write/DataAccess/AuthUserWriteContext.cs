using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOBoard.Auth.Users.Write.Domain;

namespace MOBoard.Auth.Users.Write.DataAccess
{
    public class AuthUserWriteContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AuthUserWriteContext(DbContextOptions<AuthUserWriteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Auth");
            builder.ApplyConfiguration(new AuthUserConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<RefreshToken> Tokens { get; set; }
    }
}