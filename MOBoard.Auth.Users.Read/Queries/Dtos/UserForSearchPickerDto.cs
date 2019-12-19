using System;

namespace MOBoard.Auth.Users.Read.Queries.Dtos
{
    public class UserForSearchPickerDto
    {
        public UserForSearchPickerDto(Guid id, string username, string firstName, string lastName, string avatar)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Avatar = avatar;
        }

        public Guid Id { get; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Avatar { get; }
    }
}