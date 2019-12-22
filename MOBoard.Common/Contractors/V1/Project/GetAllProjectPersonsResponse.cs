using System;

namespace MOBoard.Common.Contractors.V1.Project
{
    public class GetAllProjectPersonsResponse
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public int PermissionType { get; set; }
    }
}