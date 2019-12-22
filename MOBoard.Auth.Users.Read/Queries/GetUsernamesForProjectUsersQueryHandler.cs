using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Auth.Users.Read.DataAccess;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Extensions;
using MOBoard.Common.Handlers;

namespace MOBoard.Auth.Users.Read.Queries
{
    [UsedImplicitly]
    public class GetUsernamesForProjectUsersQueryHandler : IQueryHandler<GetUsernamesForProjectUsersQuery, IReadOnlyList<GetAllProjectPersonsResponse>>
    {
        private readonly AuthUserReadonlyContext _authUserReadonlyContext;

        public GetUsernamesForProjectUsersQueryHandler(AuthUserReadonlyContext authUserReadonlyContext)
        {
            _authUserReadonlyContext = authUserReadonlyContext;
        }

        public async Task<IReadOnlyList<GetAllProjectPersonsResponse>> HandleAsync(GetUsernamesForProjectUsersQuery query)
        {
            foreach (var projectPerson in query.GetAllProjectPersonsResponses)
            {
                var user = await _authUserReadonlyContext.Users.FirstOrDefaultAsync(p => p.Id == projectPerson.UserId && p.RemovedAt == null);
                projectPerson.Username = user.UserName;
            }

            return query.GetAllProjectPersonsResponses.ToReadOnly();
        }
    }
}