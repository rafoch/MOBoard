using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Read.Domain
{
    public class Issue : AggregateRoot
    {
        public Issue()
        {
            
        }

        public Issue(string name, DateTime? dueDate)
        {
            Name = name;
            DueDate = dueDate;
        }

        [Required]
        public string Name { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Guid CreatorId { get; private set; }
        public string Description { get; private set; }
        public ISet<IssueHistory> IssueHistories { get; set; }
    }

    public class IssueHistory : AggregateRoot
    {
        public IssueHistory(Guid userId, ActionType actionType)
        {
            UserId = userId;
            ActionType = actionType;
        }

        public Guid UserId { get; private set; }
        public ActionType ActionType { get; private set; }
        public Issue Issue { get; set; }
    }

    public enum ActionType
    {
        Created, Moved, Updated, Removed, WorkLog, Assign, Unassigned,
    }
}