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
    public class GetProjectByIdQueryHandler : IQueryHandler<GetProjectByIdQuery, GetProjectResponse>
    {
        private readonly ProjectReadonlyContext _context;

        public GetProjectByIdQueryHandler(ProjectReadonlyContext context)
        {
            _context = context;
        }

        public Task<GetProjectResponse> HandleAsync(GetProjectByIdQuery query)
        {
            return _context.Projects.Where(p => p.Id == query.Id)
                .Select(p => new GetProjectResponse
                {
                    Name = p.Name,
                    Alias = p.Alias,
                    Description = p.Description,
                    Persons = p.ProjectPersons.Select(pp => new {Type = pp.PermissionType.ToString(), Id = pp.UserId}),
                    CreatorId = p.CreatorId
                }).FirstOrDefaultAsync();
        }
    }
}