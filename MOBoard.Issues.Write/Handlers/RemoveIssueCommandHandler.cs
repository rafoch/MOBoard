using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;

namespace MOBoard.Issues.Write.Handlers
{
    [UsedImplicitly]
    public class RemoveIssueCommandHandler : ICommandHandler<RemoveIssueCommand>
    {
        private readonly IssueWriteContext _issueWriteContext;

        public RemoveIssueCommandHandler(IssueWriteContext issueWriteContext)
        {
            _issueWriteContext = issueWriteContext;
        }

        public async Task HandleAsync(RemoveIssueCommand command)
        {
            var issue = await _issueWriteContext.Issues.FirstOrDefaultAsync(i => i.Id == command.Id);
            issue.Remove();
            await _issueWriteContext.SaveChangesAsync();
        }
    }
}