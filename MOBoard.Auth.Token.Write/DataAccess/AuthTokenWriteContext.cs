using Microsoft.EntityFrameworkCore;

namespace MOBoard.Auth.Token.Write.DataAccess
{
    public class AuthTokenWriteContext : DbContext
    {
        public AuthTokenWriteContext(DbContextOptions<AuthTokenWriteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthTokenConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}