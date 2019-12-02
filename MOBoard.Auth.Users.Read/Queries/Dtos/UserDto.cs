using System;

namespace MOBoard.Auth.Users.Read.Queries.Dtos
{
    public class UserDto
    {
        public UserDto(string firstName, string lastName, Guid id, string email, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Email = email;
            UserName = username;
        }
        public string FirstName { get; }
        public string LastName { get; }
        public Guid Id { get; }
        public string Email { get; }
        public string UserName { get; }
    }
}