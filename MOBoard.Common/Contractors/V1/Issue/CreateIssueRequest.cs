using System;
using MOBoard.Common.DomainTypes;

namespace MOBoard.Common.Contractors.V1.Issue
{
    public class CreateIssueRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public string Reproduction { get; set; }
        public string AcceptanceTests { get; set; }
        public IssuePriorityLevel Priority { get; set; }
    }
}