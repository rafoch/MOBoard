using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOBoard.Auth.Users.Write.Domain;

namespace MOBoard.Auth.Users.Write.DataAccess
{
    public class AuthUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(u => u.Tokens)
                .WithOne(t => t.ApplicationUser);
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.Email).IsRequired();
        }
    }
}