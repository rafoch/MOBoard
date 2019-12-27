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
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueHistory> IssueHistories { get; set; }
        public DbSet<IssueComment> IssueComments { get; set; }
    }
}