using System.Threading.Tasks;
using MOBoard.Board.Write.Command;
using MOBoard.Board.Write.DataAccess;
using MOBoard.Board.Write.Domain;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Board.Write.Handlers
{
    public class CreateNewBoardAuthorizedCommandHandler : IAuthorizedCommandHandler<CreateNewBoardAuthorizedCommand>
    {
        private readonly BoardWriteContext _context;

        public CreateNewBoardAuthorizedCommandHandler(BoardWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(CreateNewBoardAuthorizedCommand command)
        {
            var entity = new Domain.Board(command.Name, BoardType.Normal, command.ProjectId);
            _context.Boards.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}