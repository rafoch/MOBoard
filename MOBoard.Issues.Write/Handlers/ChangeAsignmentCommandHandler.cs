using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;

namespace MOBoard.Issues.Write.Handlers
{
    [UsedImplicitly]
    public class ChangeAsignmentCommandHandler : ICommandHandler<ChangeAsignmentCommand>
    {
        private readonly IssueWriteContext _context;

        public ChangeAsignmentCommandHandler(IssueWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(ChangeAsignmentCommand command)
        {
            var issue = await _context.Issues.Include(i => i.IssueHistories).Where(x => x.Id == command.UserId).FirstOrDefaultAsync();
            issue.ChangeAssignState(command.Id);
            await _context.SaveChangesAsync();
        }
    }
}