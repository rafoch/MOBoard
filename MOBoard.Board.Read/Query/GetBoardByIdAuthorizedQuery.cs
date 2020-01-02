using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOBoard.Board.Read.DataAccess;
using MOBoard.Common.Handlers;
using MOBoard.Common.Types;

namespace MOBoard.Board.Read.Query
{
    public class GetBoardByIdAuthorizedQuery : IAuthorizedQuery<Guid>
    {
        public GetBoardByIdAuthorizedQuery(Guid boardId)
        {
            BoardId = boardId;
        }

        public Guid BoardId { get; private set; }
    }

    public class GetBoardByIdAuthorizedQueryHandler : IAuthorizedQueryHandler<GetBoardByIdAuthorizedQuery, Guid>
    {
        private readonly BoardReadonlyContext _context;

        public GetBoardByIdAuthorizedQueryHandler(BoardReadonlyContext context)
        {
            _context = context;
        }

        public async Task<Guid> HandleAsync(GetBoardByIdAuthorizedQuery authorizedQuery)
        {
            return await _context.Boards.AsQueryable().Where(b => b.Id == authorizedQuery.BoardId).Select(b => b.ProjectId).FirstOrDefaultAsync();
        }
    }
}