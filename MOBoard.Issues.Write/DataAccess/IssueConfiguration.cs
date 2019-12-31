﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOBoard.Issues.Write.Domain;

namespace MOBoard.Issues.Write.DataAccess
{
    internal class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> modelBuilder)
        {
            modelBuilder.ToTable("Issues", "Issue");
            modelBuilder.HasKey(p => p.Id);
            modelBuilder.Property(i => i.DueDate).HasColumnType("Date");
            modelBuilder.HasOne(i => i.FixedVersion)
                .WithOne(version => version.Issue)
                .HasForeignKey<FixedVersion>(i => i.IssueId);
            modelBuilder.HasMany(i => i.IssueHistories).WithOne(h => h.Issue);
            modelBuilder.HasMany(i => i.AffectedVersions).WithOne(h => h.Issue);
            modelBuilder.HasMany(i => i.IssueComments).WithOne(h => h.Issue);
        }
    }
}