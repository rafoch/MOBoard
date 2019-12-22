using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Handlers;
using MOBoard.Read.Project.DataAccess;

namespace MOBoard.Read.Project.Query
{
    [UsedImplicitly]
    public class GetProjectUsersByProjectIdQueryHandler : IQueryHandler<GetProjectUsersByProjectIdQuery, IList<GetAllProjectPersonsResponse>>
    {
        private readonly ProjectReadonlyContext _projectReadonlyContext;

        public GetProjectUsersByProjectIdQueryHandler(ProjectReadonlyContext projectReadonlyContext)
        {
            _projectReadonlyContext = projectReadonlyContext;
        }

        public async Task<IList<GetAllProjectPersonsResponse>> HandleAsync(GetProjectUsersByProjectIdQuery query)
        {
            var project = await _projectReadonlyContext.Projects.Include(p => p.ProjectPersons).FirstOrDefaultAsync(p => p.Id == query.ProjectId && p.RemovedAt == null);
            if (project != null)
            {
                return project.ProjectPersons.Select(pp => new GetAllProjectPersonsResponse
                {
                    PermissionType = (int) pp.PermissionType, 
                    UserId = pp.UserId
                }).ToList();

            }
            else
            {
                return new List<GetAllProjectPersonsResponse>();
            }
        }
    }
}