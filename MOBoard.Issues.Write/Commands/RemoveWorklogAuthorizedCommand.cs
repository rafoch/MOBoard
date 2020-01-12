using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class RemoveWorklogAuthorizedCommand : IAuthorizedCommand
    {
        public RemoveWorklogAuthorizedCommand(Guid issueId, Guid worklogId)
        {
            IssueId = issueId;
            WorklogId = worklogId;
        }

        public Guid IssueId { get; private set; }
        public Guid WorklogId { get; private set; }
    }
}