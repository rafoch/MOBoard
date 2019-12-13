using System;

namespace MOBoard.Issues.Read.Domain.State
{
    public abstract class PersonAssignmentState
    {
        public abstract void Handle(Issue issue, Guid changeUserId);
    }
}