using System;
using MOBoard.Common.DomainTypes;
using MOBoard.Common.Types;

namespace MOBoard.Read.Project.Domain
{
    public class ProjectVersion : BaseEntity<Guid>
    {
        public string Version { get; private set; }
        public string Description { get; private set; }
        public VersionType VersionType { get; private set; }
        public Project Project { get; private set; }
    }
}