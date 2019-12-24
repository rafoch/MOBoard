using System;

namespace MOBoard.Common.Contractors.V1.Issue
{
    public class ChangeAssignementRequest
    {
        public Guid ChangeUserId { get; set; }
    }

    public class EditIssueRequest
    {
        public EditIssueRequest(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}