using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Issues.Write.Commands
{
    public class RemoveCommentFromIssueCommand : IAuthorizedCommand
    {
        public RemoveCommentFromIssueCommand(Guid id, Guid commentId)
        {
            IssueId = id;
            CommentId = commentId;
        }

        public Guid IssueId { get; private set; }
        public Guid CommentId { get; private set; }
    }
}