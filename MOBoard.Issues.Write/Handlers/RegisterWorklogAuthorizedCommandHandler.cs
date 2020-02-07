using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;

namespace MOBoard.Issues.Write.Handlers
{
    public class RegisterWorklogAuthorizedCommandHandler : IAuthorizedCommandHandler<RegisterWorklogAuthorizedCommand>
    {
        private readonly IssueWriteContext _context;

        public RegisterWorklogAuthorizedCommandHandler(IssueWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(RegisterWorklogAuthorizedCommand command)
        {
            var issue = await _context.Issues
                .Include(i => i.IssueWorklogs)
                .FirstOrDefaultAsync(i => i.Id == command.IssueId);
            issue.RegisterWorklog(command.Hours, command.Minutes, command.UserId);
            await _context.SaveChangesAsync();
        }
    }

    public class RemoveWorklogAuthorizedCommandHandler : IAuthorizedCommandHandler<RemoveWorklogAuthorizedCommand> 
    {
        private readonly IssueWriteContext _context;

        public RemoveWorklogAuthorizedCommandHandler(IssueWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(RemoveWorklogAuthorizedCommand command)
        {
            var issue = await _context.Issues
                .Include(i => i.IssueWorklogs)
                .FirstOrDefaultAsync(i => i.Id == command.IssueId);
            issue.RemoveWorklog(command.WorklogId);
            await _context.SaveChangesAsync();
        }
    }
}