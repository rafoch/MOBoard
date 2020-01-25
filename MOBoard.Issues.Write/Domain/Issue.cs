using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MOBoard.Common.DomainTypes;
using MOBoard.Common.Services;
using MOBoard.Common.Types;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.Domain.OperationState;

namespace MOBoard.Issues.Write.Domain
{
    public class Issue : AggregateRoot
    {
        private readonly ISet<IssueHistory> _issueHistories = new HashSet<IssueHistory>();

        public Issue()
        {
        }

        public Issue(string name, DateTime? dueDate, Guid creatorId)
        {
            Name = name;
            DueDate = dueDate;
            CreatorId = creatorId;
        }

        
        private Issue(
            string name, 
            Guid creatorId, 
            string description, 
            Guid projectId, 
            string reproduction,
            string acceptanceTests,
            IssuePriorityLevel priorityLevel)
        {
            Name = name;
            CreatorId = creatorId;
            Description = description;
            Reproduction = reproduction;
            AcceptanceTests = acceptanceTests;
            IssueHistories = _issueHistories;
            ProjectId = projectId;
            Priority = priorityLevel;
            AssignState = new UnassignPersonPersonAssignmentState();
            IssueHistories.Add(new IssueHistory(creatorId, ActionType.Created));
            IssueComments = new HashSet<IssueComment>();
        }

        public static Issue Create(string name, Guid creatorId, string description, 
            Guid projectId, string reproduction, string acceptanceTests, IssuePriorityLevel priorityLevel)
        {
            return new Issue(name, creatorId, description, projectId, reproduction, acceptanceTests, priorityLevel);
        }
        
        [Required]
        public string Name { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Guid CreatorId { get; private set; }
        public string Description { get; private set; }
        public Guid ProjectId { get; private set; }
        public int IssueNumber { get; private set; }
        public string IssueFullNumber { get; private set; }
        public Guid? AssignedPersonId { get; set; }
        public string Reproduction { get; private set; }
        public string AcceptanceTests { get; private set; }
        public IssuePriorityLevel Priority { get; private set; }
        public FixedVersion FixedVersion { get; private set; }
        public ISet<IssueWorklog> IssueWorklogs { get; private set; }
        public ISet<IssueHistory> IssueHistories { get; private set; }
        public ISet<AffectedVersion> AffectedVersions { get; private set; }
        public ISet<IssueComment> IssueComments { get; private set; }
        [NotMapped]
        public PersonAssignmentState AssignState { get; set; }

        public void AddIssueNumber(int lastNumber, string projectAlias)
        {
            IssueNumber = ProjectAliasAndNumberingService.GenerateNextIssueNumber(lastNumber);
            IssueFullNumber = ProjectAliasAndNumberingService.GetProjectNumber(projectAlias, IssueNumber);
        }

        public void ChangeAssignState(Guid changeUserId)
        {
            if (AssignedPersonId == null)
            {
                AssignState = new UnassignPersonPersonAssignmentState();
            }
            else
            {
                AssignState = new AssignPersonPersonAssignmentState();
            }
            AssignState.Handle(this, changeUserId);
            ModifiedAt = DateTime.Now;
            AssignedPersonId = changeUserId;
        }

        public void Edit(EditIssueCommand command)
        {
            Name = command.Name;
            Description = command.Description;
        }

        public void RegisterWorklog(int hours, int minutes, Guid userId)
        {
            var issueWorklog = new IssueWorklog(hours, minutes, userId, this);
            IssueWorklogs.Add(issueWorklog);
        }

        public void RemoveWorklog(Guid id)
        {
            var issueWorklog = IssueWorklogs.First(worklog => worklog.Id == id);
            issueWorklog.Remove();
        }
        
        public void AddComment(string text, Guid creatorId)
        {
            IssueComments.Add(IssueComment.Create(text, creatorId, this));
        }

        public void RemoveComment(Guid commentId)
        {
            var issueComment = IssueComments.SingleOrDefault(comment => comment.Id == commentId);
            if (issueComment != null)
            {
                issueComment.Remove();
            }
        }
    }

    public class IssueWorklog : BaseEntity<Guid>
    {
        public IssueWorklog()
        {

        }

        public IssueWorklog(
            int hours,
            int minutes,
            Guid applicationUserId,
            Issue issue)
        {
            Hours = hours;
            Minutes = minutes;
            ApplicationUserId = applicationUserId;
            Issue = issue;
        }

        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public Guid ApplicationUserId { get; private set; }
        public Issue Issue { get; private set; }
        public Guid IssueId { get; private set; }
    }
}