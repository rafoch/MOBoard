using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MOBoard.Common.Types
{
    public static class TokenValidationParametersProvider
    {
        public static TokenValidationParameters Get()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Moraliadsaotjzset")),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };
        }
    }
}