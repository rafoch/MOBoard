using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class CreateIssueCommand : ICommand
    {
        public CreateIssueCommand(string name, Guid creatorId, string description)
        {
            Name = name;
            CreatorId = creatorId;
            Description = description;
        }

        public string Name { get; private set; }
        public Guid CreatorId { get; private set; }
        public string Description { get; private set; }
    }
}