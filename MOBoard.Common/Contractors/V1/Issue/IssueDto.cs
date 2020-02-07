using System;
using System.Collections.Generic;
using System.Linq;
using MOBoard.Common.DomainTypes;

namespace MOBoard.Common.Contractors.V1.Issue
{
    public class IssueDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reproduction { get; set; }
        public string AcceptanceTests { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IEnumerable<IssueHistoryDto> IssueHistories { get; set; }
        public int IssueNumber { get; set; }
        public string IssueFullNumber { get; set; }
        public IEnumerable<IssueCommentDto> IssueComments { get; set; }
        public decimal LoggedTime { get; set; }
        public IssuePriorityLevel Priority { get; set; }
    }

    public class IssueHistoryDto
    {
        public DateTime CreatedAt { get; set; }
        public Guid ChangeUserId { get; set; }
        public string ActionType { get; set; }
    }

    public class IssueCommentDto
    {
        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
        public string Text { get; set; }
    }
}