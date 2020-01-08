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
            modelBuilder.HasOne(i => i.FixedVersion).WithOne(h => h.Issue).HasForeignKey<FixedVersion>(i => i.IssueId);
            modelBuilder.HasMany(i => i.IssueHistories).WithOne(ih => ih.Issue).HasForeignKey(i => i.IssueId);
            modelBuilder.HasMany(i => i.AffectedVersions).WithOne(ih => ih.Issue);
            modelBuilder.HasMany(i => i.IssueComments).WithOne(ih => ih.Issue);

        }
    }

    internal class IssueHistoryConfiguration : IEntityTypeConfiguration<IssueHistory>
    {
        public void Configure(EntityTypeBuilder<IssueHistory> builder)
        {
            builder.ToTable("IssueHistory", "Issue");
            builder.Property(p => p.ActionType);
            builder.Property(p => p.UserId);
            builder.Property(p => p.IssueId);
        }
    }
}