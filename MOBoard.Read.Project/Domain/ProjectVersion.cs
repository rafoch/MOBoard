using MOBoard.Common.DomainTypes;

namespace MOBoard.Read.Project.Domain
{
    public class ProjectVersion
    {
        public string Version { get; private set; }
        public string Description { get; private set; }
        public VersionType VersionType { get; private set; }
        public Project Project { get; private set; }
    }
}