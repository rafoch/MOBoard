using System;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.DomainTypes;

namespace MOBoard.Issues.Write.Commands
{
    public class CreateIssueCommand : IAuthorizedCommand
    {
        public CreateIssueCommand(
            string name, 
            string description, 
            Guid projectId, 
            string projectAlias, 
            IssuePriorityLevel issuePriorityLevel)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
            ProjectAlias = projectAlias;
            Priority = issuePriorityLevel;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid ProjectId { get; private set; }
        public string ProjectAlias { get; private set; }
        public IssuePriorityLevel Priority { get; private set; }
    }
}