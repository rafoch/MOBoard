using System;

namespace MOBoard.Issues.Write.Domain.OperationState
{
    public class AssignPersonPersonAssignmentState : PersonAssignmentState
    {
        public override void Handle(Issue issue, Guid changeUserId)
        {
            issue.AssignState = new UnassignPersonPersonAssignmentState();
            issue.IssueHistories.Add(new IssueHistory(changeUserId, ActionType.Assign));
        }
    }
}