using System;
using System.Collections.Generic;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Read.Domain
{
    public class IssueComment : BaseEntity<Guid>
    {
        public IssueComment()
        {
            
        }

        public string Text { get; set; }
        public Guid CreatorId { get; set; }
        public Issue Issue { get; set; }
        public Guid IssueId { get; set; }
    }
}