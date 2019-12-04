using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MOBoard.Auth.Users.Write.DataAccess;
using MOBoard.Common.Contractors.V1.OAuth;
using MOBoard.Common.Dispatchers;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Write.Commands.RefreshToken
{
    [UsedImplicitly]
    public class RefreshTokenCommandHandler : IResultCommandHandler<RefreshTokenCommand, AuthenticationResult>
    {
        private readonly AuthUserWriteContext _authUserWriteContext;

        public RefreshTokenCommandHandler(AuthUserWriteContext authUserWriteContext)
        {
            _authUserWriteContext = authUserWriteContext;
        }

        public async Task<AuthenticationResult> HandleAsync(RefreshTokenCommand command)
        {
            var validatedToken = GetPrincipalFromToken(command.Token);

            if (validatedToken == null)
            {
                return new AuthenticationResult { Errors = new[] { "Invalid Token" } };
            }

            var expiryDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthenticationResult { Errors = new[] { "This token hasn't expired yet" } };
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _authUserWriteContext.Tokens.SingleOrDefaultAsync(x => x.Token == command.RefreshToken);

            if (storedRefreshToken == null)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token does not exist" } };
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpireDate)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token has expired" } };
            }

            if (storedRefreshToken.Invalidated)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token has been invalidated" } };
            }

            if (storedRefreshToken.Used)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token has been used" } };
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token does not match this JWT" } };
            }

            storedRefreshToken.Used = true;
            _authUserWriteContext.Tokens.Update(storedRefreshToken);
            await _authUserWriteContext.SaveChangesAsync();

            return new AuthenticationResult
            {
                Success = true
            };
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, TokenValidationParametersProvider.Get(), out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                       StringComparison.InvariantCultureIgnoreCase);
        }
    }
}