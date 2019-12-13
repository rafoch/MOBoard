using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MOBoard.Board.Write.DataAccess
{
    public class BoardWriteContext : DbContext
    {
        public BoardWriteContext(DbContextOptions<BoardWriteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var saveChangesAsync = await base.SaveChangesAsync(cancellationToken);
            return saveChangesAsync;
        }

        public DbSet<Domain.Board> Boards { get; set; }
        public DbSet<Domain.Column> Columns { get; set; }
    }
}