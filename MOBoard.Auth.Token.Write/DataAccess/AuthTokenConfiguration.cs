using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOBoard.Auth.Token.Write.Domain;

namespace MOBoard.Auth.Token.Write.DataAccess
{
    public class AuthTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> modelBuilder)
        {
            modelBuilder.ToTable("Auth", "RefreshToken");
            modelBuilder.Property(i => i.ExpireDate).HasColumnType("Date");
            modelBuilder.Property(i => i.CreateDate).HasColumnType("Date");
            modelBuilder.Property(i => i.Token);
            modelBuilder.Property(i => i.JwtId);
            modelBuilder.Property(i => i.Invalidated);

            modelBuilder.(i => i.ApplicationUser);
        }
    }
}