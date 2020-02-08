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
    public class GetProjectsByUserIdQueryHandler : IAuthorizedQueryHandler<GetProjectsByUserIdQuery, IList<GetProjectForUserResponse>>
    {
        private readonly ProjectReadonlyContext _context;

        public GetProjectsByUserIdQueryHandler(ProjectReadonlyContext context)
        {
            _context = context;
        }
        public async Task<IList<GetProjectForUserResponse>> HandleAsync(GetProjectsByUserIdQuery query)
        {
            return await _context.Projects
                .Include(p => p.ProjectPersons)
                .Where(p => p.ProjectPersons.Any(pp => pp.UserId == query.UserId))
                .Select(p => new GetProjectForUserResponse
                {
                    Alias = p.Alias,
                    Description = p.Description,
                    Id = p.Id,
                    Name = p.Name
                }).ToListAsync();
        }
    }
}