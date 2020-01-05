using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class CreateIssueCommand : IAuthorizedCommand
    {
        public CreateIssueCommand(string name, string description,Guid projectId,
            string projectAlias, string reproduction, string acceptanceTests)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
            ProjectAlias = projectAlias;
            Reproduction = reproduction;
            AcceptanceTests = acceptanceTests;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid ProjectId { get; private set; }
        public string ProjectAlias { get; private set; }
        public string Reproduction { get; private set; }
        public string AcceptanceTests { get; private set; }

    }
}