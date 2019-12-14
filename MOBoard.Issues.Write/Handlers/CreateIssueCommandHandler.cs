using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;
using MOBoard.Issues.Write.Domain;

namespace MOBoard.Issues.Write.Handlers
{
    [UsedImplicitly]
    public class CreateIssueCommandHandler : ICommandHandler<CreateIssueCommand>
    {
        private readonly IssueWriteContext _context;

        public CreateIssueCommandHandler(IssueWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(CreateIssueCommand command)
        {
            if (command.CreatorId != Guid.Empty && command.ProjectId != Guid.Empty)
            {
                var issueCount = _context.Issues.Count(i => i.ProjectId == command.ProjectId);
                var newIssue = Issue.CreateIssue(command.Name, command.CreatorId, command.Description, command.ProjectId);
                newIssue.AddIssueNumber(issueCount, command.ProjectAlias);
                _context.Issues.Add(newIssue);
                await _context.SaveChangesAsync();
            }
        }
    }
}