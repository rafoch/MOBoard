using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Auth.Users.Read.DataAccess;
using MOBoard.Auth.Users.Read.Queries.Dtos;
using MOBoard.Common.Extensions;
using MOBoard.Common.Handlers;

namespace MOBoard.Auth.Users.Read.Queries
{
    [UsedImplicitly]
    public class UserByIdQueryHandler : IQueryHandler<UserByIdQuery, Maybe<UserDto>>
    {
        private readonly AuthUserReadonlyContext _context;

        public UserByIdQueryHandler(AuthUserReadonlyContext context)
        {
            _context = context;
        }

        public async Task<Maybe<UserDto>> HandleAsync(UserByIdQuery query)
        {
            return (await _context.Users
                    .Where(u => u.Id == query.Id)
                    .Select(u => 
                        new UserDto(u.FirstName, u.LastName, u.Id, u.Email, u.UserName))
                    .SingleOrDefaultAsync())
                .ToMaybe();
        }
    }
}