using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOBoard.Auth.Users.Read.Domain;

namespace MOBoard.Auth.Users.Read.DataAccess
{
    public class AuthUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users", "auth");
            builder.HasMany(u => u.Tokens)
                .WithOne(t => t.ApplicationUser);
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.RemovedAt);
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.Email).IsRequired();
        }
    }
}