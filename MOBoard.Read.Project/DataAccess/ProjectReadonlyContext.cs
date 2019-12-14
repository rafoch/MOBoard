using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MOBoard.Read.Project.DataAccess
{
    public class ProjectReadonlyContext : DbContext
    {
        public ProjectReadonlyContext(DbContextOptions<ProjectReadonlyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Board");
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var saveChangesAsync = await base.SaveChangesAsync(cancellationToken);
            return saveChangesAsync;
        }

        public DbSet<Domain.Project> Projects { get; set; }
    }
}