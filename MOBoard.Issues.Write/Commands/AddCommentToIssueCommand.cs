using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class AddCommentToIssueCommand : IAuthorizedCommand
    {
        public AddCommentToIssueCommand(string text, Guid issueId)
        {
            Text = text;
            IssueId = issueId;
        }

        public string Text { get; private set; }
        public Guid IssueId { get; private set; }
    }
}