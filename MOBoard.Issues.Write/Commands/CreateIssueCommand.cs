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
            string reproduction,
            string acceptanceTests,
            string projectAlias,
            IssuePriorityLevel issuePriorityLevel)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
            ProjectAlias = projectAlias;
            Reproduction = reproduction;
            AcceptanceTests = acceptanceTests;
            Priority = issuePriorityLevel;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid ProjectId { get; private set; }
        public string ProjectAlias { get; private set; }
        public string Reproduction { get; private set; }
        public string AcceptanceTests { get; private set; }
        public IssuePriorityLevel Priority { get; private set; }
    }
}