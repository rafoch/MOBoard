using System;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Read.Domain
{
    public class FixedVersion : BaseEntity<Guid>
    {
        public FixedVersion()
        {

        }
        public Guid VersionId { get; set; }
        public Issue Issue { get; set; }
        public Guid IssueId { get; set; }
    }
}