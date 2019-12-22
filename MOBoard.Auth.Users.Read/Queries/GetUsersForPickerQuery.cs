using System.Collections.Generic;
using System.Collections.Immutable;
using MOBoard.Auth.Users.Read.Queries.Dtos;
using MOBoard.Common.Filter;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Read.Queries
{
    public class GetUsersForPickerQuery : IQuery<PagedResult<UserForSearchPickerDto>>
    {
        public GetUsersForPickerQuery(PaginationFilter paginationFilter)
        {
            PaginationFilter = paginationFilter;
        }
        public PaginationFilter PaginationFilter { get; }
    }
}