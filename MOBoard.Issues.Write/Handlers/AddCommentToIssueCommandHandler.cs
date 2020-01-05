using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;

namespace MOBoard.Issues.Write.Handlers
{
    [UsedImplicitly]
    public class AddCommentToIssueCommandHandler : IAuthorizedCommandHandler<AddCommentToIssueCommand>
    {
        private readonly IssueWriteContext _context;

        public AddCommentToIssueCommandHandler(IssueWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(AddCommentToIssueCommand command)
        {
            var issue = await _context.Issues
                .Include(issue => issue.IssueComments)
                .FirstOrDefaultAsync(issue => issue.Id == command.IssueId);
            issue.AddComment(command.Text, command.UserId);
            await _context.SaveChangesAsync();
        }
    }
}