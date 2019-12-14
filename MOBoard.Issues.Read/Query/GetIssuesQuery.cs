using System;
using System.Collections.Generic;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Read.Query
{
    public class GetIssuesQuery : IQuery<IList<IssueDto>>
    {
        public GetIssuesQuery(Guid projectId)
        {
            ProjectId = projectId;
        }

        public Guid ProjectId { get; set; }
    }
}