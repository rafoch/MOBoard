using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;

namespace MOBoard.Issues.Write.Handlers
{
    [UsedImplicitly]
    public class RemoveCommentFromIssueCommandHandler : IAuthorizedCommandHandler<RemoveCommentFromIssueCommand>
    {
        private readonly IssueWriteContext _context;

        public RemoveCommentFromIssueCommandHandler(IssueWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(RemoveCommentFromIssueCommand command)
        {
            var issue = await _context.Issues
                .Include(i => i.IssueComments)
                .FirstOrDefaultAsync(i => i.Id == command.IssueId);
            issue.RemoveComment(command.CommentId);
            await _context.SaveChangesAsync();
        }
    }
}