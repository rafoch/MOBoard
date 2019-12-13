using System;

namespace MOBoard.Issues.Write.Domain.OperationState
{
    public abstract class PersonAssignmentState
    {
        public abstract void Handle(Issue issue, Guid changeUserId);
    }
}