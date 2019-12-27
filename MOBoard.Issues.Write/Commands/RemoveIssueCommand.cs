using System;
using System.Threading.Tasks;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class RemoveIssueCommand : ICommand
    {
        public RemoveIssueCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }

    public class AuthorizedCommand : IAuthorizedCommand
    {
    }

    public class AuthorizedCommandHandler : IAuthorizedCommandHandler<AuthorizedCommand>
    {
        public async Task HandleAsync(AuthorizedCommand command)
        {
            var commandUserId = command.UserId;
            return;
        }
    }
}