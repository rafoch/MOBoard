using System;
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
}