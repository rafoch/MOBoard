using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Auth.Users.Read.Queries;
using MOBoard.Auth.Users.Read.Queries.Dtos;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Filter;
using MOBoard.Common.Types;
using MOBoard.Web.Controllers.Base;

namespace MOBoard.Web.Controllers.V1.User
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : BaseController
    {
        public UserController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet(ApiRoutes.User.Search)]
        public async Task<ActionResult<PagedResult<UserForSearchPickerDto>>> SearchForUsers([FromQuery] PaginationFilter query)
        {
            var paginationFilter = PaginationFilterBuilder.Build(query);
            var getUsersForPickerCommand = new GetUsersForPickerQuery(paginationFilter);
            var userForSearchPickerDtos = await QueryAsync(getUsersForPickerCommand);
            return Collection(userForSearchPickerDtos);
        }
    }
}