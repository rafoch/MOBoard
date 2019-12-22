using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MOBoard.Common.Contractors.V1.Project;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Read.Queries
{
    public class GetUsernamesForProjectUsersQuery : IQuery<IReadOnlyList<GetAllProjectPersonsResponse>>
    {
        public GetUsernamesForProjectUsersQuery(IList<GetAllProjectPersonsResponse> allProjectPersonsResponses)
        {
            GetAllProjectPersonsResponses = allProjectPersonsResponses;
        }

        public IList<GetAllProjectPersonsResponse> GetAllProjectPersonsResponses { get; }
    }
}