using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MOBoard.Common.Types;
using MOBoard.Issues.Read.Domain.State;

namespace MOBoard.Issues.Read.Domain
{
    public class Issue : AggregateRoot
    {
        private readonly ISet<IssueHistory> _issueHistories = new HashSet<IssueHistory>();

        public Issue()
        {
            IssueHistories = _issueHistories;
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
        public Guid ProjectId { get; private set; }
        public int IssueNumber { get; private set; }
        public string IssueFullNumber { get; private set; }
        public string Reproduction { get; private set; }
        public Guid? AssignedPersonId { get; set; }
        public FixedVersion FixedVersion { get; private set; }
        public ISet<IssueHistory> IssueHistories { get; private set; }
        public ISet<AffectedVersion> AffectedVersions { get; private set; }
        public ISet<IssueComment> IssueComments { get; private set; }
        [NotMapped]
        public PersonAssignmentState AssignState { get; set; }
    }

    public class FixedVersion : BaseEntity<Guid>
    {
        public FixedVersion()
        {

        }
        public Guid VersionId { get; set; }
        public Issue Issue { get; set; }
        public Guid IssueId { get; set; }
    }

    public class AffectedVersion : BaseEntity<Guid>
    {
        public AffectedVersion()
        {

        }

        public Guid VersionId { get; set; }
        public Issue Issue { get; set; }
        public Guid IssueId { get; set; }

    }
}