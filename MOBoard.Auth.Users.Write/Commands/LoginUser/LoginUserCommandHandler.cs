using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MOBoard.Auth.Users.Write.DataAccess;
using MOBoard.Auth.Users.Write.Domain;
using MOBoard.Common.Contractors.V1.OAuth;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Auth.Users.Write.Commands.LoginUser
{
    [UsedImplicitly]
    public class LoginUserCommandHandler : IResultCommandHandler<LoginUserCommand, TokenResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly AuthUserWriteContext _authUserWriteContext;

        public LoginUserCommandHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            AuthUserWriteContext authUserWriteContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authUserWriteContext = authUserWriteContext;
        }

        public async Task<TokenResult> HandleAsync(LoginUserCommand command)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("Moraliadsaotjzset");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, command.ApplicationUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, command.ApplicationUser.Email),
                new Claim("id", command.ApplicationUser.Id.ToString()),
            };

            var userClaims = await _userManager.GetClaimsAsync(command.ApplicationUser);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(command.ApplicationUser);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role == null) continue;
                var roleClaims = await _roleManager.GetClaimsAsync(role);

                foreach (var roleClaim in roleClaims)
                {
                    if (claims.Contains(roleClaim))
                        continue;

                    claims.Add(roleClaim);
                }
            }

            var expireDate = DateTime.UtcNow.Add(new TimeSpan(7,0,0));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var user = await _authUserWriteContext.Users.Where(u => u.Id == command.ApplicationUser.Id).FirstOrDefaultAsync();
            var refreshToken = new Domain.RefreshToken
            {
                JwtId = token.Id,
                ApplicationUser = user,
                CreateDate = DateTime.UtcNow,
                ExpireDate = expireDate
            };
            if (user.Tokens == null)
            {
                user.Tokens = new HashSet<Domain.RefreshToken>();
            }
            user.Tokens.Add(refreshToken);
            await _authUserWriteContext.SaveChangesAsync();

            return new TokenResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }
    }
}