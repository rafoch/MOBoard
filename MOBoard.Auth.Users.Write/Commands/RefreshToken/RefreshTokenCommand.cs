using MOBoard.Common.Contractors.V1.OAuth;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Auth.Users.Write.Commands.RefreshToken
{
    public class RefreshTokenCommand : ICommand<AuthenticationResult>
    {
        public RefreshTokenCommand(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
        public string Token { get; }
        public string RefreshToken { get; }
    }
}