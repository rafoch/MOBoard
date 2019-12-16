using System;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Types;

namespace MOBoard.Read.Project.Query
{
    public class GetProjectByIdQuery : IQuery<GetProjectResponse>
    {
        public GetProjectByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}