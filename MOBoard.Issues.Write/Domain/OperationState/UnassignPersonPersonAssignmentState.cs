using System;

namespace MOBoard.Issues.Write.Domain.OperationState
{
    public class UnassignPersonPersonAssignmentState : PersonAssignmentState
    {
        public override void Handle(Issue issue, Guid changeUserId)
        {
            issue.AssignState = new AssignPersonPersonAssignmentState();
            issue.IssueHistories.Add(new IssueHistory(changeUserId, ActionType.Unassigned));
        }
    }
}