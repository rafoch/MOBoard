using System;
using MOBoard.Common.Contractors.V1.Issue;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Read.Query
{
    public class GetIssueByIdQuery : IQuery<IssueDto>
    {
        public GetIssueByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}