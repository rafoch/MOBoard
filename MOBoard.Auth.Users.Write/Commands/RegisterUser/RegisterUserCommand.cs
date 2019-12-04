using System;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Auth.Users.Write.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public RegisterUserCommand(string firstName, string lastName, string email, string username)
        {
            Email = email;
            UserName = username;
        }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }
    }
}