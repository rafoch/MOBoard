using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Write.Project.Command
{
    public class RemoveUserFromProjectCommand : ICommand
    {
        public RemoveUserFromProjectCommand(Guid userId, Guid projectId, Guid requestUserId)
        {
            UserId = userId;
            ProjectId = projectId;
            RequestUserId = requestUserId;
        }

        public Guid UserId { get; }
        public Guid ProjectId { get; }
        public Guid RequestUserId { get; }
    }
}