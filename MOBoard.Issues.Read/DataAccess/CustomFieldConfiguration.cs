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
            modelBuilder.HasOne(i => i.FixedVersion).WithOne(h => h.Issue).HasForeignKey<FixedVersion>(i => i.IssueId); ;
            modelBuilder.HasMany(i => i.IssueHistories).WithOne(ih => ih.Issue);
            modelBuilder.HasMany(i => i.AffectedVersions).WithOne(ih => ih.Issue);
            modelBuilder.HasMany(i => i.IssueComments).WithOne(ih => ih.Issue);

        }
    }
}