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
            builder.HasDefaultSchema("Auth");
            builder.ApplyConfiguration(new AuthUserConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> UsersRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}