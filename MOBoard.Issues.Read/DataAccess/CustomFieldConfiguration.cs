﻿using Microsoft.EntityFrameworkCore;
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
            modelBuilder
                .HasMany(i => i.IssueWorklogs)
                .WithOne(iw => iw.Issue)
                .HasForeignKey(h => h.IssueId);

        }
    }

    internal class IssueCommentsConfiguration : IEntityTypeConfiguration<IssueComment>
    {
        public void Configure(EntityTypeBuilder<IssueComment> builder)
        {
            builder.ToTable("IssueComments", "Issue");
            builder.Property(ic => ic.Text);
            builder.Property(ic => ic.CreatorId);
            builder.HasOne(ic => ic.Issue)
                .WithMany(i => i.IssueComments)
                .HasForeignKey(ic => ic.IssueId);
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

    internal class IssueWorklogConfiguration : IEntityTypeConfiguration<IssueWorklog>
    {
        public void Configure(EntityTypeBuilder<IssueWorklog> builder)
        {
            builder.ToTable("IssueWorklog", "Issue");
            builder.Property(iw => iw.ApplicationUserId);
            builder.Property(iw => iw.Hours);
            builder.Property(iw => iw.Minutes);
            builder.Property(iw => iw.ApplicationUserId);
            builder.HasOne(iw => iw.Issue)
                .WithMany(i => i.IssueWorklogs)
                .HasForeignKey(iw => iw.IssueId);
        }
    }
}