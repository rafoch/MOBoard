using System;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Dispatchers;
using MOBoard.Write.Project.Domain;

namespace MOBoard.Write.Project.Command
{
    public class AddUserToProjectCommand : ICommand
    {
        public AddUserToProjectCommand(Guid userId, PermissionType permissionType, Guid projectId, Guid requestUserId)
        {
            UserId = userId;
            ProjectId = projectId;
            PermissionType = permissionType;
            RequestUserId = requestUserId;
        }

        public Guid UserId { get; }
        public Guid ProjectId { get; }
        public PermissionType PermissionType { get; }
        public Guid RequestUserId { get; }
    }
}