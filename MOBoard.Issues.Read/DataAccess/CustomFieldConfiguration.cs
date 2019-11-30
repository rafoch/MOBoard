using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOBoard.Issues.Read.Domain;

namespace MOBoard.Issues.Read.DataAccess
{
    internal class CustomFieldConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> modelBuilder)
        {
            modelBuilder.ToTable("Issues", "Issue");


            modelBuilder.Property(i => i.DueDate).HasColumnType("Date");
            
        }
    }
}