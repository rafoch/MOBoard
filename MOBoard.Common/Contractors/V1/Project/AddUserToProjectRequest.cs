using System;

namespace MOBoard.Common.Contractors.V1.Project
{
    public class AddUserToProjectRequest
    {
        public AddUserToProjectRequest()
        {
            
        }

        public AddUserToProjectRequest(Guid userId, int permissionType)
        {
            UserId = userId;
            PermissionType = permissionType;
        }

        public Guid UserId { get; set; }
        public int PermissionType { get; set; }
    }
}