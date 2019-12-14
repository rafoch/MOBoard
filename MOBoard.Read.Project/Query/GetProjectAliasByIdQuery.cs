using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Handlers;
using MOBoard.Common.Types;
using MOBoard.Read.Project.DataAccess;

namespace MOBoard.Read.Project.Query
{
    public class GetProjectAliasByIdQuery : IQuery<string>
    {
        public GetProjectAliasByIdQuery(Guid projectId)
        {
            ProjectId = projectId;
        }

        public Guid ProjectId { get; set; }
    }

    [UsedImplicitly]
    public class GetProjectAliasByIdQueryHandler : IQueryHandler<GetProjectAliasByIdQuery, string>
    {
        private readonly ProjectReadonlyContext _projectReadonlyContext;

        public GetProjectAliasByIdQueryHandler(ProjectReadonlyContext projectReadonlyContext)
        {
            _projectReadonlyContext = projectReadonlyContext;
        }
        public Task<string> HandleAsync(GetProjectAliasByIdQuery query)
        {
            return _projectReadonlyContext.Projects
                .Where(p => p.RemovedAt == null && p.Id == query.ProjectId)
                .Select(p => p.Alias)
                .FirstOrDefaultAsync();
        }
    }
}