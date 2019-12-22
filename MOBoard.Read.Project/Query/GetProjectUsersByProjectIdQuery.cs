using System;
using System.Collections.Generic;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Types;

namespace MOBoard.Read.Project.Query
{
    public class GetProjectUsersByProjectIdQuery : IQuery<IList<GetAllProjectPersonsResponse>>
    {
        public GetProjectUsersByProjectIdQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
        public Guid ProjectId { get; }
    }
}