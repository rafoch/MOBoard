using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOBoard.Issues.Write.Domain;

namespace MOBoard.Issues.Write.DataAccess
{
    internal class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> modelBuilder)
        {
            modelBuilder.ToTable("Issues", "Issue");
            modelBuilder.Property(i => i.DueDate).HasColumnType("Date");
        }
    }
}