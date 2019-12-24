using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class EditIssueCommand : ICommand
    {
        public EditIssueCommand(string name, string description, Guid issueId)
        {
            Name = name;
            Description = description;
            IssueId = issueId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid IssueId { get; private set; }
    }
}