using System;
using System.Collections.Generic;
using MOBoard.Common.Types;

namespace MOBoard.Read.Project.Domain
{
    public class Project : AggregateRoot
    {
        public Project(string name, string description, string @alias, Guid creatorId)
        {
            Name = name;
            Description = description;
            Alias = alias;
            CreatorId = creatorId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Alias { get; private set; }
        public Guid CreatorId { get; set; }
        public ISet<ProjectPerson> ProjectPersons { get; private set; }
    }

    public class ProjectPerson : BaseEntity<Guid>
    {
        public ProjectPerson(Guid userId, PermissionType permissionType = PermissionType.User)
        {
            UserId = userId;
            PermissionType = permissionType;
        }

        public Guid UserId { get; private set; }
        public PermissionType PermissionType { get; private set; }
    }

    public enum PermissionType
    {
        User, Creator, Admin, Moderator,
    }
}