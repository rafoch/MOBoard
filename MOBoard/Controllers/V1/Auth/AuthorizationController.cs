using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MOBoard.Auth.Users.Write.Commands;
using MOBoard.Auth.Users.Write.Domain;
using MOBoard.Common.Contractors.V1;
using MOBoard.Common.Contractors.V1.OAuth;
using MOBoard.Common.Dispatchers;
using MOBoard.Web.Controllers.Base;

namespace MOBoard.Web.Controllers.V1
{
    public class AuthorizationController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthorizationController(
            IDispatcher dispatcher, 
            UserManager<ApplicationUser> userManager) : base(dispatcher)
        {
            _userManager = userManager;
        }

        [HttpPost(ApiRoutes.Authorization.Login)]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user != null)
            {
                var checkPasswordAsync = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
                if (checkPasswordAsync && user.ChangePassword)
                {
                    return Conflict("ChangePassword");
                }

                if (checkPasswordAsync)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpPost(ApiRoutes.Authorization.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email
            };
            var identityResult = await _userManager.CreateAsync(applicationUser, registerRequest.Password);
            if (identityResult.Succeeded)
            {

            }
            return Ok();
        }
    }
}