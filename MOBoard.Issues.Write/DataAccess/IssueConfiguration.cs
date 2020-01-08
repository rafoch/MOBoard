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
            modelBuilder.HasOne(i => i.FixedVersion)
                .WithOne(version => version.Issue)
                .HasForeignKey<FixedVersion>(i => i.IssueId);
            modelBuilder.HasMany(i => i.IssueHistories).WithOne(h => h.Issue);
            modelBuilder.HasMany(i => i.AffectedVersions).WithOne(h => h.Issue);
            modelBuilder.HasMany(i => i.IssueComments).WithOne(h => h.Issue);
            modelBuilder.HasMany(i => i.IssueWorklogs).WithOne(h => h.Issue).HasForeignKey(h => h.IssueId);
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