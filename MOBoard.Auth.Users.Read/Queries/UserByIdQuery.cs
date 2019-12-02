using System;
using CSharpFunctionalExtensions;
using MOBoard.Auth.Users.Read.Queries.Dtos;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Read.Queries
{
    public class UserByIdQuery : IQuery<Maybe<UserDto>>
    {
        public UserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}