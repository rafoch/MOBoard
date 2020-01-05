﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        private Issue(string name, Guid creatorId, string description, Guid projectId, string reproduction, string acceptanceTest)
        {
            Name = name;
            CreatorId = creatorId;
            Description = description;
            Reproduction = reproduction;
            AcceptanceTests = acceptanceTest;
            IssueHistories = _issueHistories;
            ProjectId = projectId;
            AssignState = new UnassignPersonPersonAssignmentState();
            IssueHistories.Add(new IssueHistory(creatorId, ActionType.Created));
            IssueComments = new HashSet<IssueComment>();
        }

        public static Issue Create(string name, Guid creatorId, string description, Guid projectId, string reproduction, string acceptanceTest)
        {
            return new Issue(name, creatorId, description, projectId, reproduction, acceptanceTest);
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

        public FixedVersion FixedVersion { get; private set; }
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