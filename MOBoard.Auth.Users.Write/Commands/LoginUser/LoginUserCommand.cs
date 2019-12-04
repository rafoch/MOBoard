using Microsoft.Extensions.Configuration;
using MOBoard.Auth.Users.Write.Domain;
using MOBoard.Common.Contractors.V1.OAuth;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Write.Commands.LoginUser
{
    public class LoginUserCommand : ICommand<TokenResult>
    {
        public LoginUserCommand(ApplicationUser applicationUser)
        {
            ApplicationUser = applicationUser;
        }
        public ApplicationUser ApplicationUser { get; }

    }
}