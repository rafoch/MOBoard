using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Auth.Users.Read.DataAccess;
using MOBoard.Auth.Users.Read.Queries.Dtos;
using MOBoard.Common.Extensions;
using MOBoard.Common.Handlers;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Read.Queries
{
    [UsedImplicitly]
    public class GetUsersForPickerQueryHandler : IQueryHandler<GetUsersForPickerQuery, PagedResult<UserForSearchPickerDto>>
    {
        private readonly AuthUserReadonlyContext _authUserReadonlyContext;

        public GetUsersForPickerQueryHandler(AuthUserReadonlyContext authUserReadonlyContext)
        {
            _authUserReadonlyContext = authUserReadonlyContext;
        }

        public async Task<PagedResult<UserForSearchPickerDto>> HandleAsync(GetUsersForPickerQuery query)
        {
            var applicationUsers = _authUserReadonlyContext.Users.AsQueryable().Where(u => u.RemovedAt == null);
            var count = applicationUsers.Count();
            var pages =  count / query.PaginationFilter.ElementsPerPage;
            var userForSearchPickerDtos = await applicationUsers
                .Take(query.PaginationFilter.ElementsPerPage)
                .Select(u => new UserForSearchPickerDto(u.Id, u.UserName, u.FirstName, u.LastName, String.Empty))
                .SkipWithPagination(query.PaginationFilter)
                .ToListAsync();
            var users= userForSearchPickerDtos.ToReadOnly();

            return PagedResult<UserForSearchPickerDto>.Create(users, pages, count);
        }
    }
}