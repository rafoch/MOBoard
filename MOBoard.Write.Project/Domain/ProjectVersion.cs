using System;
using MOBoard.Common.DomainTypes;
using MOBoard.Common.Types;

namespace MOBoard.Write.Project.Domain
{
    public class ProjectVersion : BaseEntity<Guid>
    {
        public ProjectVersion()
        {
            
        }

        public ProjectVersion(string version, string description, VersionType versionType, Project project)
        {
            Version = version;
            Description = description;
            VersionType = versionType;
            Project = project;
        }

        public static ProjectVersion Create(string version, string description, Project project)
        {
            return new ProjectVersion(version, description, VersionType.Open, project);
        }

        public string Version { get; private set; }
        public string Description { get; private set; }
        public VersionType VersionType { get; private set; }
        public Project Project { get; private set; }
    }
}