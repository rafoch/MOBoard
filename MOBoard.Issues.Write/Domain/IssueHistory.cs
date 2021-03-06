﻿using System;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Write.Domain
{
    public class IssueHistory : BaseEntity<Guid>
    {
        public IssueHistory(Guid userId, ActionType actionType)
        {
            UserId = userId;
            ActionType = actionType;
        }

        public Guid UserId { get; private set; }
        public ActionType ActionType { get; private set; }
        public Issue Issue { get; set; }
        public Guid IssueId { get; set; }
    }
}