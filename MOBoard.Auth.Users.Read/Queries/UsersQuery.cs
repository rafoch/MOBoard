using System.Collections.Immutable;
using MOBoard.Auth.Users.Read.Queries.Dtos;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Read.Queries
{
    public class UsersQuery : IQuery<IImmutableList<UserDto>>
    {
        public UsersQuery(string keyword)
        {
            Keyword = keyword;
        }

        public string Keyword { get; }
    }
}