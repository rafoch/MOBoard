using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MOBoard.Auth.Users.Read.DataAccess;
using MOBoard.Auth.Users.Read.Queries.Dtos;
using MOBoard.Common.Extensions;
using MOBoard.Common.Handlers;

namespace MOBoard.Auth.Users.Read.Queries
{
    [UsedImplicitly]
    public class UsersQueryHandler : IQueryHandler<UsersQuery, IImmutableList<UserDto>>
    {
        private readonly AuthUserReadonlyContext _context;

        public UsersQueryHandler(AuthUserReadonlyContext context)
        {
            _context = context;
        }

        public async Task<IImmutableList<UserDto>> HandleAsync(UsersQuery query)
        {
            var userDtoQuery = _context.Users.AsQueryable();
            if (!query.Keyword.IsNullOrWhiteSpace())
            {
                userDtoQuery = userDtoQuery
                    .Where(u => (u.FirstName + ' ' + u.LastName).ToLower().Contains(query.Keyword.ToLower()));
            }

            var users = userDtoQuery.Select(u =>
                new UserDto(
                    u.FirstName,
                    u.LastName,
                    u.Id,
                    u.Email,
                    u.UserName
                )).ToImmutableList();

            return users;
        }
    }
}