using System;
using MOBoard.Common.Types;

namespace MOBoard.Write.Project.Domain
{
    public class ProjectPerson : BaseEntity<Guid>
    {
        public ProjectPerson(Guid userId, PermissionType permissionType = PermissionType.User)
        {
            UserId = userId;
            PermissionType = permissionType;
        }

        public Guid UserId { get; private set; }
        public PermissionType PermissionType { get; private set; }

        public void ChangePermission(PermissionType permission)
        {
            PermissionType = permission;
        }
    }
}