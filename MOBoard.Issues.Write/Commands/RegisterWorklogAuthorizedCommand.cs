using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class RegisterWorklogAuthorizedCommand : IAuthorizedCommand
    {
        public RegisterWorklogAuthorizedCommand(Guid issueId, int hours, int minutes)
        {
            IssueId = issueId;
            Hours = hours;
            Minutes = minutes;
        }

        public Guid IssueId { get; private set; }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
    }
}