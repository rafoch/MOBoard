using System;
using System.Threading.Tasks;
using MOBoard.Common.Dispatchers;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.DataAccess;
using MOBoard.Issues.Write.Domain;

namespace MOBoard.Issues.Write.Handlers
{
    public class CreateIssueCommandHandler : ICommandHandler<CreateIssueCommand>
    {
        private readonly IssueWriteContext _context;

        public CreateIssueCommandHandler(IssueWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(CreateIssueCommand command)
        {
            if (command.CreatorId != Guid.Empty)
            {
                _context.Issues.Add(Issue.CreateIssue(command.Name, command.CreatorId, command.Description));
                await _context.SaveChangesAsync();
            }
        }
    }
}