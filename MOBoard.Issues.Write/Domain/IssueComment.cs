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

        private IssueComment(string text, Guid creatorId, Issue issue)
        {
            Text = text;
            CreatorId = creatorId;
            Issue = issue;
        }

        public static IssueComment Create(string text, Guid creatorId, Issue issue)
            => new IssueComment(text, creatorId, issue);

        public string Text { get; private set; }
        public Guid CreatorId { get; private set; }
        public Issue Issue { get; private set; }
    }
}