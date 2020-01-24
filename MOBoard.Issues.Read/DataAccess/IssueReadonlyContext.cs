using Microsoft.EntityFrameworkCore;
using MOBoard.Issues.Read.Domain;

namespace MOBoard.Issues.Read.DataAccess
{
    public class IssueReadonlyContext : DbContext
    {
        public IssueReadonlyContext(DbContextOptions<IssueReadonlyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomFieldConfiguration());
            modelBuilder.ApplyConfiguration(new IssueHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new IssueCommentsConfiguration());
            modelBuilder.ApplyConfiguration(new IssueWorklogConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueHistory> IssueHistories { get; set; }
        public DbSet<IssueComment> IssueComments { get; set; }
        public DbSet<IssueWorklog> IssueWorklogs { get; set; }
    }
}