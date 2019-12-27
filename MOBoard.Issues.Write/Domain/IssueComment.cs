using System;
using System.Collections.Generic;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Write.Domain
{
    public class IssueComment : BaseEntity<Guid>
    {
        public IssueComment()
        {
        }

        public string Text { get; set; }
        public Guid CreatorId { get; set; }
        public Issue Issue { get; set; }
    }
}