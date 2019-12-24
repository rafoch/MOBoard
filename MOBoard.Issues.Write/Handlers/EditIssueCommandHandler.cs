using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;

namespace MOBoard.Issues.Write.Handlers
{
    [UsedImplicitly]
    public class EditIssueCommandHandler : ICommandHandler<EditIssueCommand>
    {
        private readonly IssueWriteContext _issueWriteContext;

        public EditIssueCommandHandler(IssueWriteContext issueWriteContext)
        {
            _issueWriteContext = issueWriteContext;
        }
        public async Task HandleAsync(EditIssueCommand command)
        {
            var issue = await _issueWriteContext.Issues.FirstOrDefaultAsync(i => i.Id == command.IssueId);
            issue.Edit(command);
            await _issueWriteContext.SaveChangesAsync();
        }
    }
}