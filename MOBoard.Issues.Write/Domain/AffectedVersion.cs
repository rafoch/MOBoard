using System;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Write.Domain
{
    public class AffectedVersion : BaseEntity<Guid>
    {
        public AffectedVersion()
        {
            
        }

        public Guid VersionId { get; set; }
        public Issue Issue { get; set; }
        public Guid IssueId { get; set; }
    }
}