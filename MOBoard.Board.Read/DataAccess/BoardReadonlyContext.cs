using Microsoft.EntityFrameworkCore;

namespace MOBoard.Board.Read.DataAccess
{
    public class BoardReadonlyContext : DbContext
    {
        public BoardReadonlyContext(DbContextOptions<BoardReadonlyContext> options) : base(options)
        {
        }


        public DbSet<Domain.Board> Boards { get; set; }
        public DbSet<Domain.Column> Columns { get; set; }
    }
}